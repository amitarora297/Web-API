using API_Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Data_Layer
{
    public class MedMaster
    {
        string con;
        SqlConnection cnn;
        /// <summary>
        /// Constructor
        /// </summary>
        public MedMaster()
        {
            string con = "Data Source=AMIT\\AMITPC;Initial Catalog=MedDB;Integrated Security=true";
            cnn = new SqlConnection(con);
            cnn.Open();
        }

        /// <summary>
        /// Get All Medicine
        /// </summary>
        /// <returns></returns>
        public List<Medicine> GetMedicines()
        {
            List<Medicine> lstMedicine = new List<Medicine>();
            Medicine medicine = new Medicine();
            string strSql;
            strSql = "Select * from MedMaster";
            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = cnn;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medicine = new Medicine();
                medicine.MedicineID = (int)dr["MedID"];
                medicine.MedicineName = (string)dr["MedName"];
                medicine.Purpose = (string)dr["Purpose"];
                lstMedicine.Add(medicine);
            }
            if (lstMedicine.Count == 0) return null;
            return lstMedicine;
        }
        /// <summary>
        /// Get Medicine By ID
        /// </summary>
        /// <param name="medID"></param>
        /// <returns></returns>
        public List<Medicine> GetMedicines(int medID)
        {
            List<Medicine> lstMedicine = new List<Medicine>();
            Medicine medicine = new Medicine();
            string strSql;
            strSql = "Select * from MedMaster where MedID = "+ medID.ToString() +" ";
            SqlCommand cmd = new SqlCommand(strSql);
            cmd.Connection = cnn;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medicine = new Medicine();
                medicine.MedicineID = (int)dr["MedID"];
                medicine.MedicineName = (string)dr["MedName"];
                medicine.Purpose = (string)dr["Purpose"];
                lstMedicine.Add(medicine);
            }
            if (lstMedicine.Count == 0) return null;
            return lstMedicine;
        }
        /// <summary>
        /// Add New Medicine
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public int AddMedicine(Medicine medicine)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "AddMed";
            cmd.Parameters.Add(new SqlParameter("MedName", medicine.MedicineName));
            cmd.Parameters.Add(new SqlParameter("Purpose", medicine.Purpose));
            cmd.Parameters.Add(new SqlParameter("MedID",SqlDbType.Int));
            cmd.Parameters["MedID"].Direction = ParameterDirection.Output;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["MedID"].Value;
        }
    }
}
