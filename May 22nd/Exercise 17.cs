using System;
using System.Collections.Generic;


public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Fee { get; set; }

    public override string ToString() => $"{Title} (${Fee})";
}


public interface IEnrollable
{
    void Enroll(Course course);
}


public class User : IEnrollable
{
    public string Name { get; set; }
    private List<Course> EnrolledCourses { get; } = new List<Course>();
    private decimal TotalAmountPaid { get; set; }

 
    public void Enroll(Course course)
    {
        EnrolledCourses.Add(course);
        TotalAmountPaid += course.Fee;
        Console.WriteLine($"Enrolled in: {course.Title} (Full price: ${course.Fee})");
    }

    
    public void Enroll(Course course, string couponCode)
    {
        decimal discount = GetDiscount(couponCode);
        decimal discountedFee = course.Fee * (1 - discount);

        EnrolledCourses.Add(course);
        TotalAmountPaid += discountedFee;

        Console.WriteLine($"Enrolled in: {course.Title} with coupon '{couponCode}'");
        Console.WriteLine($"Original: ${course.Fee}, Discount: {discount:P0}, Final: ${discountedFee}");
    }

    private decimal GetDiscount(string couponCode)
    {
     
        return couponCode.ToUpper() switch
        {
            "WELCOME20" => 0.20m,
            "SAVE10" => 0.10m,
            "SUMMER25" => 0.25m,
            _ => 0m 
        };
    }

    public void PrintEnrollmentSummary()
    {
        Console.WriteLine($"\nEnrollment Summary for {Name}:");
        Console.WriteLine($"Total Courses: {EnrolledCourses.Count}");
        Console.WriteLine($"Total Amount Paid: ${TotalAmountPaid}");
        Console.WriteLine("\nEnrolled Courses:");
        foreach (var course in EnrolledCourses)
        {
            Console.WriteLine($"- {course}");
        }
    }
}

class Program
{
    static void Main()
    {
       
        var pythonCourse = new Course { Id = 1, Title = "Python Programming", Fee = 199 };
        var webCourse = new Course { Id = 2, Title = "Web Development", Fee = 299 };
        var dataScienceCourse = new Course { Id = 3, Title = "Data Science", Fee = 399 };

        
        var user = new User { Name = "John Doe" };

      
        user.Enroll(pythonCourse);
        user.Enroll(webCourse, "WELCOME20");
        user.Enroll(dataScienceCourse, "SUMMER25");

        
        user.PrintEnrollmentSummary();
    }
}