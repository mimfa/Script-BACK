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
using MiMFa.Interpreters;
using MiMFa.Interpreters.Engine;
using MiMFa.Service;
using MiMFa.WPF.Service;

namespace MiMFa.UIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IInterpreter SBACK = new JavaScriptV8();
        string StartHTML = "<!--MiMFa Script-BACK-->";//"<!--MCL GUI-->";
        string EndHTML = "<!--MiMFa Script-BACK-->";//"<!--MCL GUI-->";
        List<string> ListCommand = new List<string>(); 
        public WebBrowserService BrowserBehavior = new WebBrowserService();
        public bool EventActivity = true;
        public MainWindow( )
        { 
            InitializeComponent();
            SBACK.Initialize();
            SBACK.InjectDefaultAssemblies();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            rtb.Focus();
            this.Topmost = false;
        }

        public bool Ctrl=false;
        private void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.RightCtrl || e.Key == Key.LeftCtrl)
                Ctrl = true;
        }
        int index = 0;
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Ctrl && LV.Items != null)
                switch (e.Key)
                {
                    case Key.Down:
                        if (index < LV.Items.Count && index > -1)
                            RTBS.SetInCurrentText(ref rtb, LV.Items[index++] + "");
                        else index = 0;
                        break;
                    case Key.Up:
                        if (index < LV.Items.Count && index > -1)
                            RTBS.SetInCurrentText(ref rtb, LV.Items[index--] + "");
                        else index = 0;
                        break;
                    case Key.Space:
                    case Key.Right:
                        AutoComplete();
                        break;
                    case Key.RightCtrl:
                    case Key.LeftCtrl:
                        Ctrl = false;
                        index = 0;
                        break;
                    case Key.F5:
                        ExecuteAsync();
                        break;
                }
            else
                switch (e.Key)
                {
                    case Key.F5:
                        Execute();
                        break;
                    case Key.Escape:
                        (new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd)).Text = "";
                        break;
                }
        }

        private RichTextBoxService RTBS = new RichTextBoxService();
        private void AutoComplete()
        {
            //RTBS.ExecuteInCurrentText(ref rtb, (s)=>
            //{
            //    string str = MRL.MCL.GetStructureWith(s);
            //    if(str.Length > s.Length) return str.Substring(s.Length);
            //    return "";
            //});
        }

        private void rtb_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Execute();
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            ExecuteAsync();
        }
        bool exec = false;
        bool navigating = false;
        public  Task ExecuteAsync()
        {
            return ExecuteAsync(new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text);
        }
        public  Task ExecuteAsync(string m)
        {
            return ProcessService.RunTask(() =>
            {
                Execute(m);
            });
        }
        public void Execute(params string[] args)
        {
            if (args != null && args.Length > 0)
            {
                dp.Visibility = Visibility.Collapsed;
                foreach (var item in args)
                {
                    exec = false;
                    Title = System.IO.Path.GetFileNameWithoutExtension(item);
                    HandleFileOpen(item, true);
                }
            }
            else BrowserBehavior.SetHTML(WB, "<center><h3>Welcome to Script-BACK</h3><h6>MiMFa Script Based Application Custom-made Kernel</h6></center>Press the \"F5\" key, for execute your scripts!<br>Enjoy...");
        }
        public void Execute()
        {
            Execute(new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text);
        }
        public void Execute(string m)
        {
            object v = "";
            try
            {
                v = SBACK.Evaluate(m);
                exec = true;
                BrowserBehavior.SetHTML(WB, StartHTML + v + EndHTML);
                BrowserBehavior.SetHTML(WB, StartHTML + v + EndHTML);
                LV.Items.Insert(0, m.Trim());
                ListCommand.Insert(0, BrowserBehavior.GetHTML(WB));
                LV.MaxHeight = LV.MinHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + Environment.NewLine + "Command: " + m + Environment.NewLine + "Result: " + v);
            }
        }
        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = LV.SelectedItem.ToString();
            BrowserBehavior.SetHTML(WB, ListCommand[LV.SelectedIndex]);
        }

        private void rtb_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LV.MaxHeight = rtb.ActualHeight;
        }
        private void WB_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            navigating = true;
        }
        private void WB_Navigated(object sender, NavigationEventArgs e)
        {
            Navigated();
        }
        private void Navigated()
        {
            if (exec)
            {
                exec = navigating = false;
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                LV.Items.Insert(0, textRange.Text = textRange.Text.Trim());
                ListCommand.Insert(0, BrowserBehavior.GetHTML(WB));
                textRange.Text = "";
                LV.MaxHeight = LV.MinHeight;
            }
        }
        private void rtb_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                HandleFileOpen(files[0],false);
            }
        }
        private void button_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                HandleFileOpen(files[0], true);
            }
        }
        private void HandleFileOpen(string v, bool execute)
        {
            if (!execute) (new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd)).Text = IOService.ReadText(v);
            else
            {
                EventActivity = false;
                Execute(IOService.ReadText(v,Encoding.UTF8));
                EventActivity = true;
            }
        }

    }
}

