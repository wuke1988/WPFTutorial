using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0StoreDatabase
{
    public class StoreDbDataSet
    {
        internal static DataSet ReadDataSet()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("store.xsd");
            ds.ReadXml("store.xml");
            return ds;
        }
        public DataSet GetCategoriesAndProducts()
        {
            return ReadDataSet();
        }
        public DataTable GetProducts()
        {
            return ReadDataSet().Tables[0];
        }
    }
}
