using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZM.BLL;
using ZM.Model;
namespace ClientDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<User> users = new List<User>();
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            User user = new User();
            user.Address = "xi'an";
            user.Name = "liu qiang";
            user.BirthDay = DateTime.Now;
            user.GradeID = 1;
            bll.AddEntity(user);
            GetEntitys();
        }

        private void btnGetEntitys_Click(object sender, EventArgs e)
        {
            GetEntitys();
        }

        private void GetEntitys()
        {
            UserBLL bll = new UserBLL();
            users = new List<User>();
            users = bll.GetEntitysByWhere(string.Empty, null);
            this.dataGridView1.DataSource = users;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count < 1)
                return;
            users = dataGridView1.DataSource as List<User>;
            List<User> delUsers = new List<User>();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                delUsers.Add(users.Find(p => p.ID.Equals(int.Parse(item.Cells[0].Value.ToString()))));
            }
            UserBLL bll = new UserBLL();
            bll.DeleteEntitys(delUsers);
            GetEntitys();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            users = dataGridView1.DataSource as List<User>;
            UserBLL bll = new UserBLL();
            bll.UpdateUsers(users);
            //bll.UpdateEntitys(users);
           //hello world
            string a = "";
        }
    }
}
