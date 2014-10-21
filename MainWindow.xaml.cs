using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string help;
        bool file_set = false;
        String FilePath;
        List<String> list = new List<String>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            open_file();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            edit();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            submit();
        }

        private void tb_cullom_I_with_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_cullom_I_with.Text = check_number(tb_cullom_I_with.Text);
        }

        private void tb_cullom_I_with_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_cullom_I_with.Text = "";
        }

        private void cb_cullom_I_with_Click(object sender, RoutedEventArgs e)
        {
            if (cb_cullom_I_with.IsChecked == true)
            {
                tb_cullom_I_with.IsEnabled = true;
                rb_I_center.IsEnabled = true;
                rb_I_left.IsEnabled = true;
                rb_I_right.IsEnabled = true;
            }
            else
            {
                tb_cullom_I_with.IsEnabled = false;
                rb_I_center.IsEnabled = false;
                rb_I_left.IsEnabled = false;
                rb_I_right.IsEnabled = false;
            }
        }

        private void tb_cullom_II_with_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_cullom_II_with.Text = check_number(tb_cullom_II_with.Text);
        }

        private void tb_cullom_II_with_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_cullom_II_with.Text = "";
        }

        private void cb_praefix_Click(object sender, RoutedEventArgs e)
        {
            if (cb_praefix.IsChecked == true)
            {
                tb_praefix.IsEnabled = true;
            }
            else
            {
                tb_praefix.IsEnabled = false;
            }
        }

        private void cb_cullom_II_with_Click(object sender, RoutedEventArgs e)
        {
            if (cb_cullom_II_with.IsChecked == true)
            {
                tb_cullom_II_with.IsEnabled = true;
                rb_II_center.IsEnabled = true;
                rb_II_left.IsEnabled = true;
                rb_II_right.IsEnabled = true;
            }
            else
            {
                tb_cullom_II_with.IsEnabled = false;
                rb_II_center.IsEnabled = false;
                rb_II_left.IsEnabled = false;
                rb_II_right.IsEnabled = false;
            }
        }

        private void cb_edit_Click(object sender, RoutedEventArgs e)
        {
            if (cb_edit.IsChecked == true)
            {
                tb_edit_number.IsEnabled = true;
                tb_edit_cullom_I.IsEnabled = true;
                tb_edit_cullom_II.IsEnabled = true;
            }
            else
            {
                tb_edit_number.IsEnabled = false;
                tb_edit_cullom_I.IsEnabled = false;
                tb_edit_cullom_II.IsEnabled = false;
                tb_edit_number.Text = "";
                tb_edit_cullom_I.Text = "";
                tb_edit_cullom_II.Text = "";
            }
        }

        private void tb_cullom_II_with_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb_cullom_II_with.Text == "")
            {
                tb_cullom_II_with.Text = "Spalte II Breite";
            }
        }

        private void tb_cullom_I_with_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb_cullom_I_with.Text == "")
            {
                tb_cullom_I_with.Text = "Spalte I Breite";
            }
        }

        private void rb_I_left_Click(object sender, RoutedEventArgs e)
        {
            if (rb_I_left.IsChecked == true)
            {
                rb_I_center.IsChecked = false;
                rb_I_right.IsChecked = false;
            }
        }

        private void rb_I_right_Click(object sender, RoutedEventArgs e)
        {
            if (rb_I_right.IsChecked == true)
            {
                rb_I_center.IsChecked = false;
                rb_I_left.IsChecked = false;
            }
        }

        private void rb_I_center_Click(object sender, RoutedEventArgs e)
        {
            if (rb_I_center.IsChecked == true)
            {
                rb_I_left.IsChecked = false;
                rb_I_right.IsChecked = false;
            }
        }

        private void rb_II_left_Click(object sender, RoutedEventArgs e)
        {
            if (rb_II_left.IsChecked == true)
            {
                rb_II_center.IsChecked = false;
                rb_II_right.IsChecked = false;
            }
        }

        private void rb_II_right_Click(object sender, RoutedEventArgs e)
        {
            if (rb_II_right.IsChecked == true)
            {
                rb_II_center.IsChecked = false;
                rb_II_left.IsChecked = false;
            }
        }

        private void rb_II_center_Click(object sender, RoutedEventArgs e)
        {
            if (rb_II_left.IsChecked == true)
            {
                rb_II_center.IsChecked = false;
                rb_II_right.IsChecked = false;
            }
        }

        private void tb_edit_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_edit_number.Text = check_number(tb_edit_number.Text);
            if (tb_edit_number.Text == "")
            {
                btn_edit.IsEnabled = false;
            }
            else
            {
                btn_edit.IsEnabled = true;
            }
        }

        private void tb_cullom_I_submit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_cullom_I_submit.Text == "")
            {
                btn_submit.IsEnabled = false;
            }
            else
            {
                btn_submit.IsEnabled = true;
            }
        }

        private void lb_list_view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select(lb_list_view.SelectedIndex);
        }

        private void open_file()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".tex";
            dlg.Filter = "LaTEX-Table (.tex)|*.tex";
            Nullable<bool> result = dlg.ShowDialog();
            file_set = false;
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                lbl_path_curr_data.Content = path_name(filename, 90, 70);
                file_set = true;
                FilePath = filename;
                open();
            }
        }

        private void edit()
        {
            if ((tb_edit_cullom_I.Text == "") && (tb_edit_cullom_II.Text == ""))
            {
                list.RemoveAt(Convert.ToInt16(tb_edit_number.Text));
                orderList();
                refresh_list_view();
                write_file();
                tb_edit_number.Text = "";
            }
            else
            {
                list.RemoveAt(Convert.ToInt16(tb_edit_number.Text));
                list.Add(tb_praefix.Text.Substring(0, 1) +
                        tb_edit_cullom_I.Text +
                        tb_praefix.Text.Substring(1, 1) +
                        "&" +
                        tb_edit_cullom_II.Text);
                orderList();
                refresh_list_view();
                write_file();
                tb_edit_cullom_I.Text = "";
                tb_edit_cullom_II.Text = "";
                tb_edit_number.Text = "";
            }
        }

        private void submit()
        {
            list.Add(   tb_praefix.Text.Substring(0,1) +
                        tb_cullom_I_submit.Text + 
                        tb_praefix.Text.Substring(1,1) + 
                        "&" + 
                        tb_cullom_II_submit.Text);
            orderList();
            refresh_list_view();
            write_file();
            tb_cullom_I_submit.Text = "";
            tb_cullom_II_submit.Text = "";
        }

        private string check_number(string input)
        {
            int x;
            if (int.TryParse(input, out x))
            {
                return input;
            }
            else
            {
                return "";
            }
        }

        private string path_name(string input, int displatabele_length, int ending)
        {
            
                if (input.Length < displatabele_length)
                {
                    return input;
                }
                else
                {
                    String end = input.Substring(input.Length - (ending+1));
                    String trailing = input.Substring(0, (displatabele_length-(ending+5)));
                    return trailing+" ... "+end;
                }
        }

        private void write_file()
        {
            if (file_set)
            {
                String head = "\\begin{longtable}{"+tablepropertys()+"}";
                String end = "\\end{longtable}";

                //StreamWriter delete = new StreamWriter(FilePath, false);
                //delete.WriteLine("");
                //delete.Close();

                StreamWriter sw = new StreamWriter(FilePath, false);
                sw.WriteLine(head);
                foreach(String str in list)
                {
                    sw.WriteLine(str + "\\" + "\\");
                }
                sw.WriteLine(end);
                sw.Close();
            }
        }

        private string tablepropertys()
        {
            String help="";
            if(tb_cullom_I_with.Text!=""){
                help +="lp{"+tb_cullom_I_with.Text+"cm}";
            }
            else{
                if(Convert.ToBoolean(rb_I_left.IsChecked)){
                    help += "l";
                }
                if(Convert.ToBoolean(rb_I_right.IsChecked)){
                    help += "r";
                }
                if(Convert.ToBoolean(rb_I_center.IsChecked)){
                    help += "c";
                }
            }
            if (tb_cullom_II_with.Text != "")
            {
                help += "lp{" + tb_cullom_II_with.Text + "cm}";
            }
            else
            {
                if (Convert.ToBoolean(rb_II_left.IsChecked))
                {
                    help += "l";
                }
                if (Convert.ToBoolean(rb_II_right.IsChecked))
                {
                    help += "r";
                }
                if (Convert.ToBoolean(rb_II_center.IsChecked))
                {
                    help += "c";
                }
            }
            return help;
            
        }

        private void refresh_list_view()
        {
            int i = 0;
            lb_list_view.Items.Clear();
            foreach (string lst in list)
            {
                lb_list_view.Items.Add(Convert.ToString(i)+ "     " + lst);
                i++;
            }
        }

        private void orderList()
        {
            list.Sort();
        }

        private void open()
        {
            list.Clear();
            StreamReader sr = new StreamReader(FilePath);
            string line;
            while ((line = sr.ReadLine()) != null)
	        {
		        list.Add(line.Substring(0,(line.Length-2))); 
            }
            list.RemoveAt(0);
            orderList();
            refresh_list_view();
            list.RemoveAt(list.Count-1);
            orderList();
            refresh_list_view();
        }

        private void select(int index)
        {
            String[] helper=new String[2];
            if (index >= 0)
            {
                helper = list[index].ToString().Split('&');
                tb_edit_number.Text = index.ToString();
                tb_edit_cullom_I.Text = helper[0];
                tb_edit_cullom_II.Text = helper[1];
            }
        }

    }
}
