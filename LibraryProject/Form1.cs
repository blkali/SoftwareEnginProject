using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Form1 : Form
    {
        ILibrary library;
        
        public Form1()
        {
            InitializeComponent();
            library = new Library();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddorEdit frm = new AddorEdit();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("اطلاعات کتاب ذخیره شد", "عملیات موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid();
            }
            
        }
        void BindGrid()
        {
            dgViewList.DataSource = library.selectAll();
        }

        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dgViewList.CurrentRow != null)
            {
                string name_book = dgViewList.CurrentRow.Cells[1].Value.ToString();
                int bookId = Convert.ToInt32(dgViewList.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show($"از حذف کتاب {name_book} مطمٌن هستید؟", "حذف کتاب", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    library.delete(bookId);
                    BindGrid();
                }
            }
        }

        
        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            if (dgViewList.CurrentRow != null)
            {

                AddorEdit edit = new AddorEdit();
                edit.BookId = Convert.ToInt32(dgViewList.CurrentRow.Cells[0].Value.ToString());
                edit.ShowDialog();
                if (edit.DialogResult == DialogResult.OK)
                {
                    BindGrid();
                    MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "ویرایش اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
        
        

        private void sideNavItem2_Click_1(object sender, EventArgs e)
        {
            AddorEdit frm = new AddorEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("اطلاعات کتاب ذخیره شد", "عملیات موفقیت آمیز", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid();
            }
        }

        

        private void sideNavItem1_Click(object sender, EventArgs e)
        {
            BindGrid();
            MessageBox.Show("لیست بروزرسانی شد", "بروزرسانی", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            dgViewList.DataSource = library.search_name_book(txtSearchName.Text);
        }

        private void txtSearchAuthor_TextChanged_1(object sender, EventArgs e)
        {
            dgViewList.DataSource = library.search_author(txtSearchAuthor.Text);
        }

        private void txtSearchGaner_TextChanged_1(object sender, EventArgs e)
        {
            dgViewList.DataSource = library.search_ganer(txtSearchGaner.Text);
        }

        

        private void sideNavItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("این پروژه برای درس مهندسی نرم افزار استاد گنجو می باشد", "درباره برنامه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sideNavItem3_Click(object sender, EventArgs e)
        {
            DataTable data_print = new DataTable();
            data_print.Columns.Add("Name");
            data_print.Columns.Add("Category");
            data_print.Columns.Add("Author");
            data_print.Columns.Add("Amount");

            foreach (DataGridViewRow item in dgViewList.Rows)
            {
                data_print.Rows.Add(
                    item.Cells[1].Value.ToString(),
                    item.Cells[3].Value.ToString(),
                    item.Cells[4].Value.ToString(),
                    item.Cells[6].Value.ToString()
                );
            }
            stiPrint.Load(Application.StartupPath + "/Report.mrt");
            stiPrint.RegData("DT", data_print);
            stiPrint.Show();
        }
    }
}
