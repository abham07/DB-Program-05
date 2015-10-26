//-----------------------------------------------------------------------
// <copyright file="SubmitForm.aspx.cs" company="LakeheadU">
//     Copyright ENGI-3675. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Assign_5
{
    using System;
    using Npgsql;

    /// <summary>
    /// SubmitForm is the class responsible for accepting a username and password,
    /// converting the password to MD5 hash and inserting credentials into database
    /// </summary>
    public partial class SubmitForm : System.Web.UI.Page
    {
        /// <summary>
        /// This function compares the input values with those in the database and 
        /// validates whether the user exists or is not found.
        /// </summary>
        public void ValidateLogin()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(
                "Server=127.0.0.1; Port=5432; Database=Assignment_5; Integrated Security=true;"))
            {
                string name = string.Format("{0}", Request.Form["txtName"]);
                string pwd = string.Format("{0}", Request.Form["txtPwd"]);
                string storedName = string.Empty;
                string storedPwd = string.Empty;

                conn.Open();
                string sql = "Select * from LoginTable where name = :name and password = :pwd";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue(":name", name);
                cmd.Parameters.AddWithValue(":pwd", pwd);
                
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    storedName = string.Format("{0}", dr[0]);

                    byte[] pwdRes = (byte[])dr[1];
                    storedPwd = System.Text.Encoding.UTF8.GetString(pwdRes);
                }

                if (storedName.Equals(name) && storedPwd.Equals(pwd))
                {
                    Response.Write("<span style='color: #ff0000;height:16px;width:200px;Z-INDEX:302;LEFT:5px;" +
                        "POSITION:absolute;TOP:160px'><b>USER AUTHORIZED.</b></span>");
                }
                else
                {
                    Response.Write("<span style='color: #ff0000;height:16px;width:200px;Z-INDEX:302;LEFT:5px;" + 
                        "POSITION:absolute;TOP:160px'><b>USER NOT AUTHORIZED.</b></span>");
                }
            }
        }

        /// <summary>
        /// Page_Load constructor
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if ((string.IsNullOrEmpty(Request.Form["txtName"]) && string.IsNullOrEmpty(Request.Form["txtPwd"])) != true)
                {
                    this.ValidateLogin();
                }
            }
        }
    }
}
