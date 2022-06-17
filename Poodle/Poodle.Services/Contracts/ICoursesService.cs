using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using Poodle.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<dynamic> GetAsync(User user);
		Task<Course> GetExistingCourse(int id);
		Task<List<StudentCourseViewModel>> StudentGetCourses(CourseQueryParameters filterParameters, User user);
		Task<PaginatedList<TeacherCourseViewModel>> TeacherGetCourses(CourseQueryParameters filterParameters, User user);
		Task<Course> CreateAsync(CourseDTO dto, User user);
		Task<Course> UpdateAsync(int id, User user, CourseDTO dto);
		Task<Course> DeleteAsync(int id, User user);
		Task<List<User>> GetUsersNotEnrolled(int id);
		Task<Course> EnrollStudentInPublicCourse(int id, User user);
		Task<Course> EnrollStudentsInPrivateCourse(int id, List<User> users);
		Task Unenroll(int id, User user);
	}
}
