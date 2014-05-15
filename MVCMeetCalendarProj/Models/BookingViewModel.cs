using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMeetCalendarProj.Models
{
    public class BookingViewModel
    {
      public List<bookingRequest> CurrentCalendar { get; set; }
      public string selecteditemDdlEmp { get; set; }
      public string selecteditemDdlMeetingStart { get; set; }
      public string selecteditemDdlMeetingDay { get; set; }
      public string selecteditemDdlMeetingLength { get; set; }
      public List<SelectListItem> ddlEmp { get; set; }
      public List<SelectListItem> ddlMeetingStart { get; set; }
      public List<SelectListItem> ddlMeetingDay { get; set; }
      public List<SelectListItem> ddlMeetingLength { get; set; }
      public void InitialiseEmp()
      {
          SelectListItem myItem = new SelectListItem();
          myItem.Text = "EMP001";
          myItem.Value = "EMP001";
          ddlEmp.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "EMP002";
          myItem.Value = "EMP002";
          ddlEmp.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "EMP003";
          myItem.Value = "EMP003";
          ddlEmp.Add(myItem);
      }
      public void InitialiseMeetingTime()
      {
          SelectListItem myItem = new SelectListItem();
          myItem.Text = "09:00";
          myItem.Value = "09:00";
          ddlMeetingStart.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "10:00";
          myItem.Value = "10:00";
          ddlMeetingStart.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "11:00";
          myItem.Value = "11:00";
          ddlMeetingStart.Add(myItem);
          myItem.Text = "12:00";
          myItem.Value = "12:00";
          ddlMeetingStart.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "13:00";
          myItem.Value = "13:00";
          ddlMeetingStart.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "14:00";
          myItem.Value = "14:00";
          ddlMeetingStart.Add(myItem);
          myItem.Text = "15:00";
          myItem.Value = "15:00";
          ddlMeetingStart.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "16:00";
          myItem.Value = "16:00";
          ddlMeetingStart.Add(myItem);

      }
      public void InitialiseMeetingLength()
      {
          SelectListItem myItem = new SelectListItem();
          myItem.Text = "1";
          myItem.Value = "1";
          ddlMeetingLength.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "2";
          myItem.Value = "2";
          ddlMeetingLength.Add(myItem);
      }
      public void InitialiseMeetingDay()
      {
          SelectListItem myItem = new SelectListItem();
          myItem.Text = "Today";
          myItem.Value = "1";
          ddlMeetingDay.Add(myItem);
          myItem = new SelectListItem();
          myItem.Text = "Tomorrow";
          myItem.Value = "2";
          ddlMeetingDay.Add(myItem);
      }
    }

}