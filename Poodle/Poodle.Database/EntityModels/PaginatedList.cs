using System.Collections.Generic;

namespace Poodle.Data.EntityModels
{
	public class PaginatedList<T> : List<T>
	{
		public PaginatedList()
		{
		}

		public PaginatedList(IEnumerable<T> items, int totalPages, int pageNumber)
		{
			this.AddRange(items);
			this.TotalPages = totalPages;
			this.PageNumber = pageNumber;
		}
		public bool HasPreviosPage
		{
			get
			{
				return this.PageNumber > 1;
			}

		}

		public bool HasNextPage
		{
			get
			{
				return this.PageNumber < this.TotalPages;
			}
		}

		public int TotalPages { get; }
		public int PageNumber { get; }
	}
}
