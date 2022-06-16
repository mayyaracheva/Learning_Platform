﻿
namespace Poodle.Services.Constants
{
	public static class ConstantsContainer
	{
		//Course
		public const string COURSE_NOT_FOUND = "Course was not found";
		public const string COURSE_EXISTS = "This course already exists";
		public const string COURSE_CREATED = "Course has been created";
		public const string COURSE_UPDATED = "Course has been updated";
		public const string COURSE_DELETED = "Course has been deleted";

		//User
		public const string USER_EXISTS = "This user already exists";
		public const string USER_UPDATED = "User has been updated";
		public const string USER_CREATED = "User has been created";
		public const string USER_DELETED = "User has been deleted";
		public const string USER_NOT_FOUND = "User was not found";
		public const string TEACHER = "Teacher";
		public const string Student = "Student";

		//Section
		public const string SECTION_EXISTS = "Section with such title already exists";
		public const string RESTRICTED_SECTION_TITLE = "RESTRICTED";
		public const string SECTIONS_NOT_FOUND = "The course contains no sections";
		public const string SECTIONS_DELETED = "The section was removed";

		//Categories
		public const string PUBLIC_CATEGORY = "Public";

		//Access
		public const string INVALID_CREDENTIALS = "Invalid credentials or not existing user";
		public const string RESTRICTED_ACCESS = "You are not authorized to perform this action";

		//Image
		public const string DEFAULT_IMAGEURL = "/img/DefaultImage.jpg";

		//FileLogger
		public const string FILELOGGER_FILE = "filelogger.txt";



	}
}
