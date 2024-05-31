//#define HOME
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.nvg79.connector
{
    /// <summary>
    /// Перечисление наиболее распространённых ошибок 
    /// </summary>
    public enum EMySQLErrore
    {
        /// <summary>
        /// Не возможно соединиться с сервером.
        /// </summary>
        CannotConnect=0,
        /// <summary>
        /// Не правильное имя пользователя или пароль
        /// </summary>
        InvalidUserNamePassword=1045
    }
    /// <summary>
    /// Набор компонент для простой работы с MySQL базой данных.
    /// </summary>
    public class MySQLData
    {
        String connectionString;
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        public DataSet Data{get;set;}
        public String DataMember { get; private set; }
        //public int ErroreCode { get; private set; }
        public bool HasErrore { get; private set; }
        public bool Connected { get; private set; }
        public int RowsCount { get { if (Connected && Data != null && Data.Tables != null && Data.Tables.Count > 0) return Data.Tables[0].Rows.Count; else return -1; } }
        public DataTable Table { get { if (Connected && Data != null && Data.Tables!=null && Data.Tables.Count>0) return Data.Tables[0]; else return null; } }
        public DataRow this[int index]
        {
            get { if (Connected && Data != null&&index>=0&&index<Data.Tables[0].Rows.Count) return Data.Tables[0].Rows[index]; else return null; }
        }
        public List<DataRow> this[int startIndex,int endIndex]
        {
            get
            {
                if (Connected && Data != null && startIndex >= 0 && startIndex < RowsCount && endIndex >= startIndex && endIndex < RowsCount)
                {
                    List<DataRow> rows = new List<DataRow>();
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        rows.Add(this[i]);
                    }
                    return rows;
                }
                else return null;
            }
        }
        public Object this[int index,string field]
        {
            get {
                if (Connected && Data != null && index >= 0 && index < Data.Tables[0].Rows.Count)
                {
                    try
                    {
                        return Data.Tables[0].Rows[index][field];
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                else
                    return null;
            }
            set {
                if (Connected && Data != null && index >= 0 && index < Data.Tables[0].Rows.Count)
                {
                    try
                    {
                        Data.Tables[0].Rows[index][field]=value;
                    }
                    catch (Exception)
                    {
                        //throw new Exception();
                    }
                }
            }
        }
        //public MySQLData(DBUser user,string schema)
        //{
        //    connectionString = ConnectionString(user, schema);
        //}
        public MySQLData(String host,String login,String pass, string schema)
        {
            connectionString = ConnectionString(host,login,pass,schema);
        }
        public MySQLData(String connectionString)
        {
            this.connectionString=connectionString;
        }
        public class MOpResalt
        {
            public bool HasErrore { get; private set; }
            public string ErroreText { get; private set; }
            public int ErroreCode { get; private set; }
            public MOpResalt()
            {
                HasErrore = false;
                ErroreText = "";
                ErroreCode = 0;
            }
            public MOpResalt(string text,int code)
            {
                HasErrore = true;
                ErroreText = text;
                ErroreCode = code;
            }
        }
        /// <summary>
        /// Соединение с сервером MySQL
        /// </summary>
        /// <returns>Результат соединения</returns>
        public MOpResalt Connect()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                conn.Open();
                Connected = true;
                return new MOpResalt();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Connected = false;
                return new MOpResalt(ex.Message,ex.Number);
            }
        }
        public void Close()
        {
            if(Connected)
            {
                conn.Close();
                Connected = false;
            }
        }
        /// <summary>
        /// Связывание с данными
        /// </summary>
        /// <param name="sql">Строка запроса</param>
        /// <param name="table">Наименование таблицы</param>
        /// <returns></returns>
        public MOpResalt Linking(String sql,string table)
        {
            try
            {
                adapter = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
                Data = new DataSet();
                adapter.Fill(Data, table);
                DataMember = table;
                return new MOpResalt();                
            }
            catch (MySqlException ex)
            {
                //HasErrore = true;
                //Logger.Log("Errore in linking "+ ex.Message);
                return new MOpResalt(ex.Message,ex.Number);
            }
        }
        public MOpResalt Update()
        {
            try
            {
                adapter.Update(Data,DataMember);
                return new MOpResalt();
            }
            catch (MySqlException ex)
            {
                //HasErrore = true;
                //Logger.Log("Update errore in linking "+ex.Message);
                return new MOpResalt(ex.Message,ex.Number);
            }
        }

        #region Statics
        //"server = localhost; user id = collector; password = collectorpass; persistsecurityinfo = True; database = plant"
        //        public static String Connection()
        //        {
        //#if HOME
        //            return "server = localhost; user id = guest; persistsecurityinfo = True; database = plant";
        //#else
        //            return "server = 10.8.128.2; user id = guest; persistsecurityinfo = True; database = plant";
        //#endif
        //        }
        //        public static String Connection(String login, String pass)
        //        {
        //#if HOME
        //            String connection = "server = localhost; ";
        //#else
        //            String connection = "server = 10.8.128.2; ";
        //#endif
        //            connection += " user id = " + login + ";";
        //            connection += " password = " + pass + ";";
        //            connection += "persistsecurityinfo = True; database = plant";
        //            return connection;
        //        }
        //        public static String Connection(String login, String pass, String db)
        //        {
        //#if HOME
        //            String connection = "server = localhost; ";
        //#else
        //            String connection = "server = 10.8.128.2; ";
        //#endif
        //            connection += " user id = " + login + ";";
        //            connection += " password = " + pass + ";";
        //            connection += "persistsecurityinfo = True;";
        //            connection += " database = " + db;
        //            return connection;
        //        }

        /// <summary>
        /// Функция определяет наличие записей с определенным значением
        /// </summary>
        /// <param name="table">Наименование таблицы</param>
        /// <param name="row">Наименование столбца</param>
        /// <param name="value">Искомое значение</param>
        /// <param name="connection">Строка соединения с базой данных</param>
        /// <returns>Результат</returns>
        public static bool Contain(string table, string row, string value, string connection)
        {
            GetScalar.Result result = GetScalar.Scalar("select count(*) from " + table + " where " + row + "='" + value + "';", connection);
            if (result.HasError || result.ResultText == "") return false;
            int count; if (!int.TryParse(result.ResultText, out count)) return false;
            if (count > 0) return true; else return false;
        }

        /// <summary>
        /// Создание строки соединения с сервером с кодировкой utf8_general_ci
        /// </summary>
        /// <param name="host">Сервер</param>
        /// <param name="login">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <param name="db">База данных</param>
        /// <returns>Строка соединения</returns>
        public static String ConnectionString(String host, String login, String pass, String db)
        {
            String connection = "server = " + host + "; ";
            connection += " user id = " + login + ";";
            connection += " password = " + pass + ";";
            connection += " database = " + db + ";";
            connection += "charset = utf8";// _general_ci";
            return connection;
        }
        /// <summary>
        /// Создание строки соединения с сервером
        /// </summary>
        /// <param name="host">Сервер</param>
        /// <param name="login">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <param name="db">База данных</param>
        /// <param name="charset">Кодировка</param>
        /// <returns></returns>
        public static String ConnectionString(String host, String login, String pass, String db,string charset)
        {
            String connection = "server = " + host + "; ";
            connection += " user id = " + login + ";";
            connection += " password = " + pass + ";";
            connection += " database = " + db + ";";
            connection += "charset = "+charset;
            return connection;
        }
        ///// <summary>
        ///// Создание строки соединения с сервером на основе пльзователя <see cref="DBUser"/> с кодировкой utf8_general_ci
        ///// </summary>
        ///// <param name="user">Данные пользователя <see cref="DBUser"/></param>
        ///// <param name="db">База данных</param>
        ///// <returns>Строка соединения</returns>
        //public static String ConnectionString(DBUser user, string db)
        //{
        //    String connection = "server = " + user.Host + "; ";
        //    //connection += " user id = " + user.Login + ";";
        //    //connection += " password = " + user.Pass + ";";
        //    connection += " user id = superuser;";
        //    connection += " password = superpass;";
        //    connection += " database = " + db + ";";
        //    connection += "charset = utf8";
        //    return connection;
        //}
        ///// <summary>
        ///// Создание строки соединения с сервером на основе пльзователя <see cref="DBUser"/>
        ///// </summary>
        ///// <param name="user">Данные пользователя <see cref="DBUser"/></param>
        ///// <param name="db">База данных</param>
        ///// <param name="charset">Кодировка</param>
        ///// <returns>Строка соединения</returns>
        //public static String ConnectionString(DBUser user, string db,string charset)
        //{
        //    String connection = "server = " + user.Host + "; ";
        //    connection += " user id = " + user.Login + ";";
        //    connection += " password = " + user.Pass + ";";
        //    connection += " database = " + db+";";
        //    connection+= "charset = "+charset;
        //    return connection;
        //}
        /// <summary>
        /// Преобразование времени в формат MySQL для вставки командой insert
        /// </summary>
        /// <param name="time">Время <see cref="DateTime"/></param>
        /// <returns>Строка времени для вставки командой insert</returns>
        public static String MysqlDateTime(DateTime time)
        {
            int год, день, месяц, час, минута, секунда;
            год = time.Year;
            месяц = time.Month;
            день = time.Day;
            час = time.Hour;
            минута = time.Minute;
            секунда = time.Second;
            String smonth, sday, shour, smin, ssec;
            if (месяц.ToString().Length == 2) smonth = месяц.ToString(); else smonth = "0" + месяц.ToString();
            if (день.ToString().Length == 2) sday = день.ToString(); else sday = "0" + день.ToString();
            if (час.ToString().Length == 2) shour = час.ToString(); else shour = "0" + час.ToString();
            if (минута.ToString().Length == 2) smin = минута.ToString(); else smin = "0" + минута.ToString();
            if (секунда.ToString().Length == 2) ssec = секунда.ToString(); else ssec = "0" + секунда.ToString();
            return год + "-" + smonth + "-" + sday + " " + shour + ":" + smin + ":" + ssec;
        }
        /// <summary>
        /// Преобразование времени в формат MySQL для вставки командой insert
        /// </summary>
        /// <param name="time">Время <see cref="TimeSpan"/></param>
        /// <returns>Строка времени для вставки командой insert</returns>
        public static String MysqlTime(TimeSpan time)
        {
            int час, минута, секунда;
            час = time.Hours;
            минута = time.Minutes;
            секунда = time.Seconds;
            String shour, smin, ssec;
            if (час.ToString().Length == 2) shour = час.ToString(); else shour = "0" + час.ToString();
            if (минута.ToString().Length == 2) smin = минута.ToString(); else smin = "0" + минута.ToString();
            if (секунда.ToString().Length == 2) ssec = секунда.ToString(); else ssec = "0" + секунда.ToString();
            return shour + ":" + smin + ":" + ssec;
        }
        public static String ConvertInsertData(List<String> data)
        {
            List<String> result = new List<string>();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Contains(","))
                    result.Add("\'" + data[i].Replace(",", ".") + "\'");
                else if (data[i].Equals("не число"))
                    result.Add("\'0\'");
                else if (data[i].Equals("False"))
                    result.Add("\'0\'");
                else if (data[i].Equals("True"))
                    result.Add("\'1\'");
                else
                    result.Add("\'" + data[i] + "\'");

            }
            return String.Join(", ", result);
        }
        
        public static Boolean ConvertInsertData(Dictionary<String, String> data, out String Keys, out String Values)
        {
            List<String> keys = new List<string>(), values = new List<string>();
            Keys = ""; Values = "";
            try
            {
                foreach (KeyValuePair<String, String> item in data)
                {
                    if (item.Value.Contains(","))
                        values.Add("\'" + item.Value.Replace(",", ".") + "\'");
                    else if (item.Value.Equals("не число"))
                        values.Add("\'0\'");
                    else if (item.Value.Equals("False"))
                        values.Add("\'0\'");
                    else if (item.Value.Equals("True"))
                        values.Add("\'1\'");
                    else
                        values.Add("\'" + item.Value + "\'");
                    keys.Add(item.Key);
                }
                Keys = String.Join(", ", keys);
                Values = String.Join(", ", values);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Ошибка конвертирования словаря в строку " + ex.Message);
#endif
                //Logger.Log("Ошибка конвертирования словаря в строку " + ex.Message);
                return false;
            }
        }
        public static MOpResalt Write(string sql,string connection)
        {
            try
            {
                MySqlConnection connRC = new MySqlConnection(connection);
                MySqlCommand commRC = new MySqlCommand(sql, connRC);
                connRC.Open();
                try
                {
                    commRC.ExecuteNonQuery();
                    connRC.Close();
                    return new MOpResalt();
                }
                catch (MySqlException ex)
                {
                    connRC.Close();
                    return new MOpResalt(ex.Message,ex.Number);
                }
                catch (Exception ex)
                {
                    connRC.Close();
                    return new MOpResalt(ex.Message, -1);
                }
            }
            catch (MySqlException ex)
            {
                return new MOpResalt(ex.Message,ex.Number);
            }
        }
        public class WriteDictionary:Dictionary<String,String>
        {
            public String Connection { get; private set; }
            public WriteDictionary(String connection)
            {
                Connection = connection;
            }
            /// <summary>
            /// Метод добавляяет поле для записи в таблицу (название поля должно совпадать с названием поля в исходной таблице)
            /// </summary>
            /// <param name="field">Название поля</param>
            /// <param name="data">Исходная таблица</param>
            /// <param name="row">Индекс строки в исходной таблице</param>
            /// <returns>Результат операции</returns>
            public bool AddSingle(string field, MySQLData data,int row)
            {
                if (Keys.Contains(field)) return false;
                Single value;
                if (Single.TryParse(data[row, field].ToString(), out value))
                {
                    Add(field, value.ToString());
                    return true;
                }
                else
                    return false;
            }
            /// <summary>
            /// Метод добавляяет поле для записи в таблицу
            /// </summary>
            /// <param name="destField">Название добавляемого поля</param>
            /// <param name="sourceField">Название исходного поля</param>
            /// <param name="data">Исходная таблица</param>
            /// <param name="row">Индекс строки в исходной таблице</param>
            /// <returns>Результат операции</returns>
            public bool AddSingle(string destField,string sourceField, MySQLData data, int row)
            {
                if (Keys.Contains(destField)) return false;
                Single value;
                if (Single.TryParse(data[row, sourceField].ToString(), out value))
                {
                    Add(destField, value.ToString());
                    return true;
                }
                else
                    return false;
            }
            public MOpResalt Update(string table,string where)
            {
                List<String> values = new List<string>();
                String sql="update "+table+" set ";
                try
                {
                    foreach (KeyValuePair<String, String> item in this)
                    {
                        if (item.Value.Contains(","))
                            values.Add(item.Key+"=\'" + item.Value.Replace(",", ".") + "\'");
                        else if (item.Value.Equals("не число"))
                            values.Add(item.Key+"=\'0\'");
                        else if (item.Value.Equals("False"))
                            values.Add(item.Key + "=\'0\'");
                        else if (item.Value.Equals("True"))
                            values.Add(item.Key + "=\'1\'");
                        else
                            values.Add(item.Key + "=\'" + item.Value + "\'");
                    }
                    sql += String.Join(",", values);
                    sql += " where " + where + ";";
                    return MySQLData.Write(sql, Connection);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("Ошибка обновления записи "+where+" таблицы "+table+" : " + ex.Message);
#endif
                    //Logger.Log("Ошибка обновления записи " + where + " таблицы " + table + " : " + ex.Message);
                    return new MOpResalt(ex.Message,-1);
                }
            }
            public MOpResalt Insert(String table)
            {
                List<String> keys = new List<string>(), values = new List<string>();
                String skeys = "", svalues = "";
                try
                {
                    foreach (KeyValuePair<String, String> item in this)
                    {
                        if (item.Value.Contains(","))
                            values.Add("\'" + item.Value.Replace(",", ".") + "\'");
                        else if (item.Value.Equals("не число"))
                            values.Add("\'0\'");
                        else if (item.Value.Equals("False"))
                            values.Add("\'0\'");
                        else if (item.Value.Equals("True"))
                            values.Add("\'1\'");
                        else
                            values.Add("\'" + item.Value + "\'");
                        keys.Add(item.Key);
                    }
                    skeys = String.Join(", ", keys);
                    svalues = String.Join(", ", values);
                    return MySQLData.Write("insert into " + table + " (" + skeys + ") values (" + svalues + ");",Connection);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("Ошибка конвертирования словаря в строку " + ex.Message);
#endif
                    //Logger.Log("Ошибка конвертирования словаря в строку " + ex.Message);
                    return new MOpResalt(ex.Message,-1);
                }
            }
        }
        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением одного параметра либо без параметров вовсе.
        /// </summary>
        public class GetScalar
        {
            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class Result
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public string ResultText;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }

            /// <summary>
            /// Для выполнения запросов к MySQL с возвращением 1 параметра.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает значение при успешном выполнении запроса, текст ошибки - при ошибке.</returns>
            public static Result Scalar(string sql, string connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }
            /// <summary>
            /// Для выполнения запросов к MySQL с возвращением 1 параметра.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает значение при успешном выполнении запроса, текст ошибки - при ошибке.</returns>
            public static Result Scalar(string sql, MySqlConnection connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection.ConnectionString);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }

            /// <summary>
            /// Для выполнения запросов к MySQL без возвращения параметров.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает True - ошибка или False - выполнено успешно.</returns>
            public static Result NoResponse(string sql, string connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        commRC.ExecuteNonQuery();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }
            /// <summary>
            /// Для выполнения запросов к MySQL без возвращения параметров.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает True - ошибка или False - выполнено успешно.</returns>
            public static Result NoResponse(string sql, MySqlConnection connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection.ConnectionString);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        commRC.ExecuteNonQuery();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }
        }

        /// <summary>
        /// Методы реализующие выполнение запросов с возвращением набора данных.
        /// </summary>
        public class GetData
        {
            /// <summary>
            /// Возвращаемый набор данных.
            /// </summary>
            public class Result
            {
                /// <summary>
                /// Возвращает результат запроса.
                /// </summary>
                public System.Data.DataTable ResultData;
                /// <summary>
                /// Возвращает True - если произошла ошибка.
                /// </summary>
                public string ErrorText;
                /// <summary>
                /// Возвращает текст ошибки.
                /// </summary>
                public bool HasError;
            }


            /// <summary>
            /// Выполняет запрос выборки набора строк.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает набор строк в DataSet.</returns>
            public static Result Table(string sql, string connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();

                    try
                    {
                        MySqlDataAdapter AdapterP = new MySqlDataAdapter
                        {
                            SelectCommand = commRC
                        };
                        DataSet ds1 = new DataSet();
                        AdapterP.Fill(ds1);
                        result.ResultData = ds1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        result.HasError = true;
                        result.ErrorText = ex.Message;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }

                return result;

            }
            /// <summary>
            /// Выполняет запрос выборки набора строк.
            /// </summary>
            /// <param name="sql">Текст запроса к базе данных</param>
            /// <param name="connection">Строка подключения к базе данных</param>
            /// <returns>Возвращает набор строк в DataSet.</returns>
            public static Result Table(string sql, MySqlConnection connection)
            {
                Result result = new Result();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection.ConnectionString);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();

                    try
                    {
                        MySqlDataAdapter AdapterP = new MySqlDataAdapter();
                        AdapterP.SelectCommand = commRC;
                        DataSet ds1 = new DataSet();
                        AdapterP.Fill(ds1);
                        result.ResultData = ds1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        result.HasError = true;
                        result.ErrorText = ex.Message;
                    }
                    connRC.Close();
                }
                catch (Exception ex)//Этот эксепшн на случай отсутствия соединения с сервером.
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }

                return result;

            }
        }
        #endregion
    }
}
