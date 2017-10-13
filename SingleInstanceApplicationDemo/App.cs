using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SingleInstanceApplicationDemo
{
    class App:System.Windows.Application
    {
        public List<Document> Documents
        {
            get;set;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DocumentList list = new DocumentList();
            this.MainWindow = list;

            list.Show();            
        }

        public void ShowDocument(string fileName)
        {

        }
    }
}
