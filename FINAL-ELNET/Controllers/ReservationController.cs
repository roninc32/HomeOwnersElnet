using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FINAL_ELNET.Models;

namespace FINAL_ELNET.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public IActionResult Index()
        {
            // Initialize available facility types
            ViewBag.FacilityTypes = new List<string> 
            { 
                "Function Hall", 
                "Swimming Pool", 
                "Tennis Court", 
                "Basketball Court", 
                "Gym", 
                "Barbecue Area", 
                "Meeting Room" 
            };

            // Pass available times
            var availableTimes = new List<string>();
            for (int hour = 6; hour <= 22; hour++)
            {
                availableTimes.Add($"{hour:00}:00");
            }
            ViewBag.AvailableTimes = availableTimes;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, save the reservation to the database here
                // For demonstration, we'll just redirect to a success view
                TempData["Success"] = "Facility reserved successfully!";
                TempData["ReservationDetails"] = $"You've booked {model.FacilityType} on {model.ReservationDate.ToShortDateString()} from {model.StartTime} to {model.EndTime}";
                
                return RedirectToAction("Success");
            }

            // If model state is invalid, reload the page with the same model
            // Initialize available facility types
            ViewBag.FacilityTypes = new List<string> 
            { 
                "Function Hall", 
                "Swimming Pool", 
                "Tennis Court", 
                "Basketball Court", 
                "Gym", 
                "Barbecue Area", 
                "Meeting Room" 
            };

            // Pass available times
            var availableTimes = new List<string>();
            for (int hour = 6; hour <= 22; hour++)
            {
                availableTimes.Add($"{hour:00}:00");
            }
            ViewBag.AvailableTimes = availableTimes;
            
            return View("Index", model);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult MyReservations()
        {
            // In a real application, fetch user's reservations from the database
            // For demonstration, create some sample reservations
            var reservations = new List<ReservationViewModel>
            {
                new()
                {
                    Id = 1,
                    FacilityType = "Swimming Pool",
                    ReservationDate = DateTime.Now.AddDays(3),
                    StartTime = TimeSpan.Parse("14:00"),
                    EndTime = TimeSpan.Parse("16:00"),
                    Status = "Confirmed"
                },
                new()
                {
                    Id = 2,
                    FacilityType = "Function Hall",
                    ReservationDate = DateTime.Now.AddDays(10),
                    StartTime = TimeSpan.Parse("18:00"),
                    EndTime = TimeSpan.Parse("22:00"),
                    Status = "Pending Approval"
                }
            };

            return View(reservations);
        }
    }
}