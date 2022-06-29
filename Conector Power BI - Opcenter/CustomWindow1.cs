using Preactor;
using Preactor.Interop.PreactorObject;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Conector_Power_BI___Opcenter
{
    /// <summary>
    /// Interface for the custom window. It must contain at least two methods called OnOpen and OnClose
    /// </summary>
    [ComVisible(true)]
    [Guid("b624ad08-1e01-4384-9f7d-eb67f074b58a")]
    public interface ICustomWindow1
    {
        /// <summary>
        /// Called when Preactor opens this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        int OnOpen(ref PreactorObj preactorComObject, ref string parameter);

        
        /// <summary>
        /// Called when Preactor closes this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occurred return 0 (zero)</returns>
        int OnClose(ref PreactorObj preactorComObject, ref string parameter);
    }

    /// <summary>
    /// Concrete implementation of the custom window
    /// </summary>
    [ComVisible(true)]
    [Guid("2b7ae90d-2c87-4d77-91e1-f918d5ff3831")]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class CustomWindow1 : UserControl, ICustomWindow1
    {
        private IPreactor preactor;

        /// <summary>
        /// Constructs the custom window
        /// </summary>
        public CustomWindow1()
        {
            InitializeComponent();
        }

        #region ICustomWindow Members

        /// <summary>
        /// Called when Preactor opens this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        public int OnOpen(ref PreactorObj preactorComObject, ref string parameter)
        {
            preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            return 0;
        }

        /// <summary>
        /// Called when Preactor closes this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        public int OnClose(ref PreactorObj preactorComObject, ref string parameter)
        {
            return 0;
        }

        #endregion
    }
}
