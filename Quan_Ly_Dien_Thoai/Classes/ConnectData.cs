using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Dien_Thoai.Classes
{
    internal class ConnectData
    {
        string strConnect = "Data Source=TOMMYWIN002\\SQLEXPRESS;Initial Catalog=BTL_C#;Integrated Security=True"; // Máy Thuong nha :)))
        //string strConnect = "Data Source=DESKTOP-HVO99UR\\VANH;Initial Catalog=BTL_C#;Integrated Security=True";//máy của vanh nha ae :)))
        //string strConnect = "Data Source=DELL-FINID\\SQLEXPRESS;Initial Catalog=BTL_C#;Integrated Security=True"; // proplayer's server
        //string strConnect = "Data Source=LAPTOP-I8NHT8P4;Initial Catalog=BTL_C#;Integrated Security=True"; //Nghia's DB
        //string strConnect = "Data Source=DELL-FINID\\SQLEXPRESS;Initial Catalog=BTL_C#;Integrated Security=True"; // proplayer's server
        //string strConnect = "Data Source=LAPTOP-I8NHT8P4;Initial Catalog=BTL_C#;Integrated Security=True"; //Nghia's DB
        SqlConnection sqlConn = null;

        // opening connect method
        void OpenConnect()
        {
            sqlConn = new SqlConnection(strConnect);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
        //Closing connect method
        void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        //insert,update,delete data
        public void UpdateData(string sql)
        {
            OpenConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = sql;
            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
        //Select data to return a DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter sqldata = new SqlDataAdapter(sqlSelect, sqlConn);
            sqldata.Fill(dt);
            CloseConnect();
            sqldata.Dispose();
            return dt;
        }
    }
}
