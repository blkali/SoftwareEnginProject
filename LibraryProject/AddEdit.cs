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
    public partial class AddorEdit : Form
    {
        ILibrary library_add;
        public int BookId = 0;
        public AddorEdit()
        {
            InitializeComponent();
            library_add =new Library();
        }

        private void AddorEdit_Load(object sender, EventArgs e)
        {
            if(BookId == 0)
            {
                this.Text = "افزودن کتاب";
            }
            else
            {
                this.Text = "ویرایش کتاب";
                btnSubmit.Text = "ویرایش";
                groupBox1.Text = "ویرایش کتاب";

                DataTable data = library_add.selectRow(BookId);
                txtBookName.Text = data.Rows[0][1].ToString();
                txtPublished.Text = data.Rows[0][2].ToString();
                txtGaner.Text = data.Rows[0][3].ToString();
                txtAuthor.Text = data.Rows[0][4].ToString();
                numCountPage.Value = Convert.ToInt32(data.Rows[0][5].ToString());
                numPrice.Value = Convert.ToInt32(data.Rows[0][6].ToString());

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isValidated())
            {
                if(BookId != 0)
                {
                    library_add.update(BookId, txtBookName.Text, txtPublished.Text,txtGaner.Text,txtAuthor.Text, Convert.ToInt32(numCountPage.Value), Convert.ToInt32(numPrice.Value));
                    DialogResult = DialogResult.OK;
                }
                else
                { 
                    library_add.insert(txtBookName.Text, txtPublished.Text, txtAuthor.Text,txtGaner.Text,Convert.ToInt32(numCountPage.Value),Convert.ToInt32(numPrice.Value));
                    DialogResult = DialogResult.OK;
                }
            }
        }
        bool isValidated()
        {
            if (txtBookName.Text == "")
            {
                MessageBox.Show("لطفا نام کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPublished.Text == "")
            {
                MessageBox.Show("لطفا تاریخ انتشار کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtGaner.Text == "")
            {
                MessageBox.Show("لطفا دسته بندی کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAuthor.Text == "")
            {
                MessageBox.Show("لطفا نویسنده کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToInt32(numCountPage.Value) == 0)
            {
                MessageBox.Show("لطفا تعداد صفحه کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToInt32(numPrice.Value) == 0)
            {
                MessageBox.Show("لطفا قیمت کتاب را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
