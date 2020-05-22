using Hyland.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOnBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Hyland.Unity.SingleSignOnAuthenticationProperties props = Application.CreateSingleSignOnAuthenticationProperties("URL", "Datasource");
            Hyland.Unity.Application app = Application.Connect(props);
            if (app != null)
            {
                DocumentType docType = app.Core.DocumentTypes.Find("Test Doc Type");
                Document doc = app.Core.GetDocumentByID(12345);

                KeywordType kt = app.Core.KeywordTypes.Find("test");
               
                //DocumentType docType = app.Core.DocumentTypes.Find("test");
                

                using (PageData pd = app.Core.Retrieval.Default.GetDocument(doc.Revisions[0].DefaultRendition))
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        byte[] buff = new byte[1024];
                        int read;
                        while ((read = pd.Stream.Read(buff, 0, buff.Length)) > 0)
                        {
                            ms.Write(buff, 0, read);
                        }
                        //fileLength = ms.Length;
                    }
                }
            }
        }
    }
}
