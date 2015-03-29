using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Home_Booking_BookTicket : System.Web.UI.Page
{
    #region Protected Methods(Events)
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setDefaultValues();
        }
    }
    #endregion

    #region Private Methods
    private void setDefaultValues()
    {
        CalendarExtender_DateOfJourney.SelectedDate = DateTime.Now;
        CalendarExtender_DateOfJourney.StartDate = DateTime.Now;
        CalendarExtender_DateOfJourney.EndDate = DateTime.Now.AddDays(15);
    }
    #endregion
}