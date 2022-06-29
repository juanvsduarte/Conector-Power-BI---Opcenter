using CefSharp;
using CefSharp.WinForms;
using Preactor;
using Preactor.Interop.PreactorObject;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Conector_Power_BI_Opcenter
{
    
    [ComVisible(true)]
    [Guid("7946597a-9890-4341-b2ed-b60f9cbc549c")]
    public interface IJanelaRelatorio
    {
        int OnOpen(ref PreactorObj preactorComObject, ref string URL);

        int OnClose(ref PreactorObj preactorComObject);
    }

  
    [ComVisible(true)]
    [Guid("ffa469cc-f52d-4269-8246-0682d6ee0b53")]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class JanelaRelatorio : UserControl, IJanelaRelatorio
    {
        private IPreactor preactor;
        public ChromiumWebBrowser browser;
        
        public JanelaRelatorio()
        {
            InitializeComponent();
        }

        

        
        public int OnOpen(ref PreactorObj preactorComObject, ref string URL)
        {
            preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            VG.Link = URL;
            
            InitBrowser();
            return 0;
        }

        
        public int OnClose(ref PreactorObj preactorComObject)
        {
            Dispose();
            browser.Dispose();

            return 0;
        }
        public void InitBrowser()
        {

            if (!Cef.IsInitialized)// checa se foi iniciado
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }
            browser = new ChromiumWebBrowser(VG.Link);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
        
    }
}
