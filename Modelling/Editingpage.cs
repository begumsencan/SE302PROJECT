using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Modelling
{
    public partial class Editingpage : Form
    {
       public Editingpage()
        {
            InitializeComponent(); 
           
        }
        public void update()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Yarı Yıl Aktiviteleri";
            dataGridView1.Columns[1].Name = "Sayı";
            dataGridView1.Columns[2].Name = "Katkı Payı %";
            dataGridView1.Columns[3].Name = "LO";

            ArrayList row = new ArrayList();
            row.Add("Participation");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Laboratory / Application");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Field Work    ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Quizzes / Studio Critiques    ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Homework / Assignments    ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Presentation / Jury    ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Project ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Seminar / Workshop ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Oral Exams ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Midterm ");
            dataGridView1.Rows.Add(row.ToArray());
            row = new ArrayList();
            row.Add("Final Exam     ");
            dataGridView1.Rows.Add(row.ToArray());
        }
        static int a = 1;
        
        private void button1_Click_1(object sender, EventArgs e)
        {   //adds columns
            //add LO button editlenecek
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            var htmlDoc = new HtmlDocument();
            Encoding utf8 = Encoding.UTF8;


            var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");
            int c = dataGridView1.ColumnCount;
            dataGridView1.ColumnCount++;
            a++;
            dataGridView1.Columns[c++].Name = "LO" + a.ToString();

            string[] tags = { "particip", "lab", "field", "quiz", "hw", "prsnt", "project", "seminar", "oral", "mid", "fin", "total" };
            int i = 0;
            int y = 0;


            foreach (HtmlNode ss in doc.DocumentNode.SelectNodes("//table[@id='evaluation_table1']//tr"))
            {

                if (y == 0)
                {
                    string nodec = "<td style=width: 15 %  align=center><strong>LO" + a + "</strong></td>";
                    var html2 = HtmlNode.CreateNode(nodec);
                    ss.AppendChild(html2);
                    Console.WriteLine(ss.OuterHtml);
                    y++;
                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

                    continue;
                }
                string nodecr = "<td><div class=editinput id=LO" + a + tags[i] + ">-</div></td>";
                var html = HtmlNode.CreateNode(nodecr);
                ss.AppendChild(html);
                Console.WriteLine(ss.OuterHtml);
                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

                i++;
            }
        }

        private void Editingpage_Load(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
     

        
   
        private void button2_Click(object sender, EventArgs e)
        {//submit button editlenecek
            dataGridView1.ReadOnly = false;
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            string[] patharray = {
            "//div[ @id='attendance_no']",
            "//div[ @id='attendance_per']",
             "//div[ @id='LO1attend']",


            "//div[ @id='lab_no']",
            "//div[ @id='lab_per']",
            "//div[ @id='LO1lab']",

            "//div[ @id='fieldwork_no']",
            "//div[ @id='fieldwork_per']",
             "//div[ @id='LO1field']",

             "//div[ @id='quiz_no']",
             "//div[ @id='quiz_per']",
             "//div[ @id='LO1quiz']",

             "//div[ @id='homework_no']",
             "//div[ @id='homework_per']",
            "//div[ @id='LO1homework']",

              "//div[ @id='presentation_no']",
             "//div[ @id='presentation_per']",
            "//div[ @id='LO1present']",

            "//div[ @id='project_no']",
             "//div[ @id='project_per']",
             "//div[ @id='LO1project']",

             "//div[ @id='seminar_no']",
             "//div[ @id='seminar_per']",
             "//div[ @id='LO1seminar']",

            "//div[ @id='portfolios__no']",
             "//div[ @id='portfolios_per']",
            "//div[ @id='LO1portfolio']",

            "//div[ @id='midterm_no']",
            "//div[ @id='midterm_per']",
            "//div[ @id='LO1mid']",

             "//div[ @id='final_no']",
             "//div[ @id='final_per']",
             "//div[ @id='LO1final']",

           //"//div[ @id='ara_total_no']",
           //  "//div[ @id='ara_total_per']",
           //  "//div[ @id='LOsum']"  
            };


            var htmlDoc = new HtmlDocument();
            Encoding utf8 = Encoding.UTF8;
            var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

            //HtmlNode node = doc.DocumentNode.SelectSingleNode(xpath);
            //HtmlNode node1 = doc.DocumentNode.SelectSingleNode(xpath1);
            int c = 0;
            for (int i = 0; i < 11; i++)
            {

                if (c <= 33)
                {

                    HtmlNode node = doc.DocumentNode.SelectSingleNode(patharray[c]);
                    HtmlNode node1 = doc.DocumentNode.SelectSingleNode(patharray[c + 1]);
                    HtmlNode node2 = doc.DocumentNode.SelectSingleNode(patharray[c + 2]);
                    if ((string)dataGridView1.Rows[i].Cells["Sayı"].Value != null)
                    {
                        node.InnerHtml = node.InnerHtml.Replace(node.InnerText, (string)dataGridView1.Rows[i].Cells["Sayı"].Value);
                    }
                    else
                    {
                        node.InnerHtml = node.InnerHtml.Replace(node.InnerText, "-");
                    }

                    if ((string)dataGridView1.Rows[i].Cells["Katkı Payı %"].Value != null)
                    {
                        node1.InnerHtml = node.InnerHtml.Replace(node.InnerText, (string)dataGridView1.Rows[i].Cells["Katkı Payı %"].Value);
                    }
                    else
                    {
                        node1.InnerHtml = node.InnerHtml.Replace(node.InnerText, "-");
                    }

                    if ((string)dataGridView1.Rows[i].Cells["LO"].Value != null)
                    {
                        node2.InnerHtml = node.InnerHtml.Replace(node.InnerText, (string)dataGridView1.Rows[i].Cells["LO"].Value);
                    }
                    else
                    {
                        node2.InnerHtml = node.InnerHtml.Replace(node.InnerText, "-");
                    }
                    c = c + 3;
                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
                }
            }
        }
        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e){}

        private void panel1_Paint(object sender, PaintEventArgs e){}

        private void courseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) { 
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='course_name']");
            NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, courseName.Text);
            
            doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);}
        }

        private void courseCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='course_code']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, courseCode.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        } 
        private void FallSemester_Click(object sender, EventArgs e)
        {

            if (FallSemester.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='semester']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "Güz");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='semester']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void SpringSemester_Click(object sender, EventArgs e)
        {

            if (SpringSemester.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='semester']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "Bahar");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='semester']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }
        

        private void Theory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='weekly_hours']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, Theory.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void ApplicationLab_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='app_hours']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, ApplicationLab.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void LocalCredit_KeyPress(object sender, KeyPressEventArgs e)
        {       
            double c = Convert.ToInt32(Theory.Text) + Convert.ToInt32(ApplicationLab.Text) * 0.25;//yerel kredi hesabı
            LocalCredit.Text = Convert.ToString(c);//klavyeden tuşa basınca çalışıyor
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");
               

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='ieu_credit']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, LocalCredit.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void ECTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='ects_credit']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, ECTS.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void Prerequisites_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='pre_requisites']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, Prerequisites.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void Language_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='course_lang']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, Language.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void CourseType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='course_type']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, CourseType.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void CourseLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='course_level']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, CourseLevel.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void Coordinator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='coordinators']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, Coordinator.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void ogretimElemani_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='lecturers']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, ogretimElemani.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void Yardimcilar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='assistants']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, Yardimcilar.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void CourseBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\turkishTemplate.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='book_name']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, CourseBook.Text);

                doc.Save(@"C:\Users\asus\Desktop\turkishTemplate.html", Encoding.UTF8);
            }
        }

        private void CourseMaterials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\turkishTemplate.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='materials']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, CourseMaterials.Text);

                doc.Save(@"C:\Users\asus\Desktop\turkishTemplate.html", Encoding.UTF8);
            }

        }

        private void courseObjective_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\turkishTemplate.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='purpose']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, courseObjective.Text);

                doc.Save(@"C:\Users\asus\Desktop\turkishTemplate.html", Encoding.UTF8);
            }
        }

        private void LearningOutcomesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\turkishTemplate.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='LO_yazili']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, LearningOutcomesBox.Text);

                doc.Save(@"C:\Users\asus\Desktop\turkishTemplate.html", Encoding.UTF8);
            }
        }  
        private void CoreCourses_Click(object sender, EventArgs e)
        {
            if (CoreCourses.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='core_course']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='core_course']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void MajorCourses_Click(object sender, EventArgs e)
        {
            if (MajorCourses.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='major_area']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='major_area']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void SupportiveCourses_Click(object sender, EventArgs e)
        {
            if (SupportiveCourses.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='supportive_courses']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='supportive_courses']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void MediaCourses_Click(object sender, EventArgs e)
        {
            if (MediaCourses.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='media_man_skills']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='media_man_skills']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void TransferableCourses_Click(object sender, EventArgs e)
        {
            if (TransferableCourses.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='trans_skills']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='trans_skills']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }
        private void konu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu1.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu3.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu4.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu5.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu6']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu6.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu7']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu7.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu8']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu8.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu9']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu9.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void konu10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu10']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu10.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void konu11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu11']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu11.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu12']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu12.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu13']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu13.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu14']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu14.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu15']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu15.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void konu16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='konu16']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, konu16.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void hazirlik1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik1.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void hazirlik3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik3.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void hazirlik4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik4.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik5.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik6']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik6.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik7']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik7.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik8']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik8.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik9']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik9.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik10']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik10.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik11']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik11.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik12']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik12.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void hazirlik13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik13']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik13.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik14']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik14.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik15']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik15.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void hazirlik16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//div[ @id='hazirlik16']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, hazirlik16.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }
        private void katki1_1_Click(object sender, EventArgs e)
        {
            if (katki1_1.Checked == true)
                {
                    HtmlWeb web = new HtmlWeb();
                    web.OverrideEncoding = Encoding.UTF8;
                    var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                    HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki1']");
                    NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
                }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }


        private void katki1_2_Click(object sender, EventArgs e)
        {
            if (katki1_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki1_3_Click(object sender, EventArgs e)
        {
            
                if (katki1_3.Checked == true)
                {
                    HtmlWeb web = new HtmlWeb();
                    web.OverrideEncoding = Encoding.UTF8;
                    var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                    HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki3']");
                    NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
                }
            else{
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }


        }

        private void katki1_4_Click(object sender, EventArgs e)
        {
            if (katki1_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki1_5_Click(object sender, EventArgs e)
        {
            if (katki1_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }
        private void katkiLO1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                    HtmlWeb web = new HtmlWeb();
                    web.OverrideEncoding = Encoding.UTF8;
                    var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                    HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='1katki_LO']");
                    NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO1.Text);

                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
                
            }
        }
        private void katki2_1_Click(object sender, EventArgs e)
        {
            if (katki2_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki2_2_Click(object sender, EventArgs e)
        {
            if (katki2_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki2_3_Click(object sender, EventArgs e)
        {
            if (katki2_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
           else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki2_4_Click(object sender, EventArgs e)
        {
            if (katki2_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki2_5_Click(object sender, EventArgs e)
        {
            if (katki2_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }
        private void katkiLO2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='2katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
           

        }
        private void katki3_1_Click(object sender, EventArgs e)
        {
            if (katki3_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki3_2_Click(object sender, EventArgs e)
        {
            if (katki3_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki3_3_Click(object sender, EventArgs e)
        {
            if (katki3_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki3_4_Click(object sender, EventArgs e)
        {
            if (katki3_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki3_5_Click(object sender, EventArgs e)
        {
            if (katki3_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }
        private void katkiLO3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                    HtmlWeb web = new HtmlWeb();
                    web.OverrideEncoding = Encoding.UTF8;
                    var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                    HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='3katki_LO']");
                    NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText,katkiLO3.Text);

                    doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
           

        }
        private void katki4_1_Click(object sender, EventArgs e)
        {
            if (katki4_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki4_2_Click(object sender, EventArgs e)
        {
            if (katki4_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki4_3_Click(object sender, EventArgs e)
        {
            if (katki4_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki4_4_Click(object sender, EventArgs e)
        {
            if (katki4_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki4_5_Click(object sender, EventArgs e)
        {
            if (katki4_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        } 
        private void katkiLO4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='4katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO4.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }

        }

       private void katki5_1_Click(object sender, EventArgs e)
        {

            if (katki5_1.Checked)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);


            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        
        private void katki5_2_Click(object sender, EventArgs e)
        {
            if (katki5_2.Checked)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);


            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }
      
        

        private void katki5_3_Click(object sender, EventArgs e)
        {
            if (katki5_3.Checked)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);


            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki5_4_Click(object sender, EventArgs e)
        {
            if (katki5_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki5_5_Click(object sender, EventArgs e)
        {
            if (katki5_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        

        private void katkiLO5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='5katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO5.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki6_1_Click(object sender, EventArgs e)
        {
            if (katki6_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki6_2_Click(object sender, EventArgs e)
        {
            if (katki6_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki6_3_Click(object sender, EventArgs e)
        {
            if (katki6_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki6_4_Click(object sender, EventArgs e)
        {
            if (katki6_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki6_5_Click(object sender, EventArgs e)
        {
            if (katki6_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katkiLO6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='6katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO6.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki7_1_Click(object sender, EventArgs e)
        {
            if (katki7_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki7_2_Click(object sender, EventArgs e)
        {
            if (katki7_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki7_3_Click(object sender, EventArgs e)
        {
            if (katki7_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki7_4_Click(object sender, EventArgs e)
        {
            if (katki7_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki7_5_Click(object sender, EventArgs e)
        {
            if (katki7_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katkiLO7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='7katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO7.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }

        }

        private void katki8_1_Click(object sender, EventArgs e)
        {
            if (katki8_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki8_2_Click(object sender, EventArgs e)
        {
            if (katki8_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki8_3_Click(object sender, EventArgs e)
        {
            if (katki8_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki8_4_Click(object sender, EventArgs e)
        {
            if (katki8_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki8_5_Click(object sender, EventArgs e)
        {
            if (katki8_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katkiLO8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='8katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO8.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }

        }

        private void katki9_1_Click(object sender, EventArgs e)
        {

            if (katki9_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki9_2_Click(object sender, EventArgs e)
        {
            if (katki9_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki9_3_Click(object sender, EventArgs e)
        {

            if (katki9_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki9_4_Click(object sender, EventArgs e)
        {
            if (katki9_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki9_5_Click(object sender, EventArgs e)
        {
            if (katki9_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katkiLO9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='9katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO9.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
           
        }

        private void katki10_1_Click(object sender, EventArgs e)
        {
            if (katki10_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki10_2_Click(object sender, EventArgs e)
        {
            if (katki10_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki10_3_Click(object sender, EventArgs e)
        {
            if (katki10_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki10_4_Click(object sender, EventArgs e)
        {
            if (katki10_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki10_5_Click(object sender, EventArgs e)
        {
            if (katki10_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katkiLO10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='10katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO10.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki11_1_Click(object sender, EventArgs e)
        {
            if (katki11_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki11_2_MouseClick(object sender, MouseEventArgs e)
        {
            if (katki11_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki11_3_Click(object sender, EventArgs e)
        {
            if (katki11_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki11_4_Click(object sender, EventArgs e)
        {
            if (katki11_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki11_5_Click(object sender, EventArgs e)
        {
            if (katki11_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katkiLO11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='11katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO11.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki12_1_Click(object sender, EventArgs e)
        {
            if (katki12_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki12_2_Click(object sender, EventArgs e)
        {
            if (katki12_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki12_3_Click(object sender, EventArgs e)
        {
            if (katki12_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki12_4_Click(object sender, EventArgs e)
        {
            if (katki12_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki12_5_Click(object sender, EventArgs e)
        {
            if (katki12_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katkiLO12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='12katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO12.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void katki13_1_Click(object sender, EventArgs e)
        {
            if (katki13_1.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki13_2_Click(object sender, EventArgs e)
        {
            if (katki13_2.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki13_3_Click(object sender, EventArgs e)
        {
            if (katki13_3.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }else
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki3']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }

        }

        private void katki13_4_Click(object sender, EventArgs e)
        {
            if (katki13_4.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki4']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katki13_5_Click(object sender, EventArgs e)
        {
            if(katki13_5.Checked == true)
            {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "X");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
            else {
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki5']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, "-");

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);
            }
        }

        private void katkiLO13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='13katki_LO']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, katkiLO13.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void icKatki1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='icKatki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, icKatki1.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void icKatki2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='icKatki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, icKatki2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void sonKatki1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='sonKatki1']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, sonKatki1.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void sonKatki2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='sonKatki2']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, sonKatki2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void toplam1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='total_no']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, toplam1.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void toplam2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='total_per']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, toplam2.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //save button
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update button
        }

        private void dersTanimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.UTF8;
                var doc = web.Load(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html");

                HtmlNode NameNode = doc.DocumentNode.SelectSingleNode("//td[ @id='description']");
                NameNode.InnerHtml = NameNode.InnerHtml.Replace(NameNode.InnerText, dersTanimi.Text);

                doc.Save(@"C:\Users\asus\Desktop\tmps\TurkishTemplateEdited.html", Encoding.UTF8);

            }
        }
    }
}

