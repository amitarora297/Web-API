using API_Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Data_Layer
{
    public class MedMaster
    {
        public List<Medicine> GetMedicines()
        {
            List<Medicine> lstMedicine = new List<Medicine>();
            Medicine medicine = new Medicine();
            string con = "Data Source=AMIT\\AMITPC;Initial Catalog=MedDB;Integrated Security=true";
            SqlConnection cnn;
            cnn = new SqlConnection(con);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Select * from MedMaster");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = cnn;
            SqlDataReader dr =  cmd.ExecuteReader();

            while (dr.Read())
            {
                medicine = new Medicine();
                medicine.MedicineID = (int)dr["MedID"];
                medicine.MedicineName = (string)dr["MedName"];
                medicine.Purpose = (string)dr["Purpose"];
                lstMedicine.Add(medicine);
            }

            return lstMedicine;
        }
        
    }
}
