using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListDictHashTable1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> studentGradeList = new List<string>();
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        Hashtable myHastable = new Hashtable();

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1 column setup
            listView1.Columns.Add("First and Last Name", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("GPA", 350, HorizontalAlignment.Left);

            // 2 column setup
            listView2.Columns.Add("Item", 200, HorizontalAlignment.Left);
            listView2.Columns.Add("Quantity In Stock", 350, HorizontalAlignment.Left);

            // 3 column setup
            listView3.Columns.Add("Book ID", 125, HorizontalAlignment.Left);
            listView3.Columns.Add("Book Title", 375, HorizontalAlignment.Left);

            // ADD TO DATA STRUCTURES
            // default students
            studentGradeList.Add("Will Johson");
            studentGradeList.Add("3.52");
            studentGradeList.Add("Deborah Ray");
            studentGradeList.Add("3.91");
            studentGradeList.Add("Corey Hines");
            studentGradeList.Add("2.71");
            studentGradeList.Add("David Bacon");
            studentGradeList.Add("3.10");

            // default inventory items
            myDictionary.Add("Apples", "300");
            myDictionary.Add("Bananas", "100");
            myDictionary.Add("Cherries", "900");
            myDictionary.Add("Pears", "200");
            myDictionary.Add("Oranges", "228");

            // default books with hashtable
            myHastable.Add("B01H43JCTU", "Be Obsessed or Be Average");

            //ADD TO LISTVIEWS

            for (int i = 0; i < studentGradeList.Count; i += 2)
            {
                ListViewItem students = new ListViewItem();
                students.Text = studentGradeList[i];
                students.SubItems.Add(studentGradeList[i + 1]);
                listView1.Items.Add(students);
            }

            foreach (KeyValuePair<string, string> entry in myDictionary)
            {
                // find way to add key and its value to list item
                ListViewItem inventory = new ListViewItem();
                inventory.Text = entry.Key;
                inventory.SubItems.Add(entry.Value);
                listView2.Items.Add(inventory);
            }

            foreach (DictionaryEntry de in myHastable)
            {
                ListViewItem myBookView = new ListViewItem();
                myBookView.Text = (string) de.Key;
                myBookView.SubItems.Add(Convert.ToString(de.Value));
                listView3.Items.Add(myBookView);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool quit = false;
            bool nameNotEntered = true;
            string name = "";
            string gpa = "";
            while (nameNotEntered == true)
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("Please enter the first and last name:", "Enter Name, (Type \"n\" to quit)");

                if (name.ToLower() == "n")
                {
                    quit = true;
                    break;
                }

                else if (name == "")
                {
                    MessageBox.Show("Please enter a first and last name");
                }

                else if (name != "")
                {
                    nameNotEntered = false;
                }
            }

            bool gpaNotEntered = true;
            while (gpaNotEntered == true)
            {
                gpa = Microsoft.VisualBasic.Interaction.InputBox("Please enter GPA value:", "Enter GPA, (Type \"n\" to quit)");

                if (quit == true)
                {
                    break;
                }

                else if (gpa == "")
                {
                    MessageBox.Show("Please enter a GPA");
                }

                else if (gpa != "")
                {
                    gpaNotEntered = false;
                }
            }

            // method call to adding values to list view
            if (quit != true)
            {
                addToList(name, gpa);
            }
        }

        private void addToList(string value, string value2, string listNum = "1")
        {
            if (listNum == "1")
            {
                ListViewItem students = new ListViewItem();
                students.Text = value;
                students.SubItems.Add(value2);
                listView1.Items.Add(students);
            }
            else if (listNum == "2")
            {
                ListViewItem stock = new ListViewItem();
                stock.Text = value;
                stock.SubItems.Add(value2);
                listView2.Items.Add(stock);
            }

            else if (listNum == "3")
            {
                ListViewItem books = new ListViewItem();
                books.Text = value;
                books.SubItems.Add(value2);
                listView3.Items.Add(books);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool nameNotEntered = true;
            bool quit = false;
            string item = "";
            string amount = "";
            while (nameNotEntered == true)
            {
                item = Microsoft.VisualBasic.Interaction.InputBox("Please enter item name", "Enter Name, Type \"n\" to quit)");

                if (item == "")
                {
                    MessageBox.Show("Please enter item name");
                }

                else if (item != "")
                {
                    nameNotEntered = false;
                }

                else if (item.ToLower() == "n")
                {
                    quit = true;
                    break;
                }
            }

            bool itemNotEntered = true;
            while (itemNotEntered == true)
            {
                amount = Microsoft.VisualBasic.Interaction.InputBox("Please enter inventory amount", "Enter quantity, (Type \"n\" to quit)");

                if (quit == true)
                {
                    break;
                }

                else if (amount == "")
                {
                    MessageBox.Show("Please enter a quantity");
                }

                else if (amount != "")
                {
                    itemNotEntered = false;
                    myDictionary.Add(item, amount);
                }
            }

            string listNum = "2";
            // method call to adding values to list view
            addToList(item, amount, listNum);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            bool nameNotEntered = true;
            bool quit = false;
            string bookID = "";
            string bookTitle = "";
            while (nameNotEntered == true)
            {
                bookID = Microsoft.VisualBasic.Interaction.InputBox("Please enter ID", "Enter Book ID, Type \"n\" to quit)");

                if (bookID == "")
                {
                    MessageBox.Show("Please enter item name");
                }

                else if (bookID != "")
                {
                    nameNotEntered = false;
                }

                else if (bookID.ToLower() == "n")
                {
                    quit = true;
                    break;
                }
            }

            bool itemNotEntered = true;
            while (itemNotEntered == true)
            {
                bookTitle = Microsoft.VisualBasic.Interaction.InputBox("Please enter inventory amount", "Enter quantity (Type \"n\" to quit)");

                if (quit == true)
                {
                    break;
                }

                else if (bookTitle == "")
                {
                    MessageBox.Show("Please enter a quantity");
                }

                else if (bookTitle != "")
                {
                    itemNotEntered = false;
                    myDictionary.Add(bookID, bookTitle);
                }

                else if (bookID.ToLower() == "n")
                {
                    quit = true;
                    break;
                }
            }

            string listNum = "3";
            // method call to adding values to list view
            addToList(bookID, bookTitle, listNum);
        }
    }
}
