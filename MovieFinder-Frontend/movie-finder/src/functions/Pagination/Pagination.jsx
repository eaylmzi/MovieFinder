import React from "react";
import { Link } from "react-router-dom";

class Pagination extends React.Component {
  // Method to render page numbers and navigation links
  renderPageNumbers = (totalPages, currentPage, setCurrentPage) => {
    const pageNumbers = [];
    const isFirstPage = currentPage === 1;
    const isLastPage = currentPage === totalPages;

    // Determine the range of page numbers to display
    const startPage = Math.max(1, currentPage - 1);
    const endPage = Math.min(totalPages, currentPage + 1);

    // Loop through the page numbers within the specified range
    for (let i = startPage; i <= endPage; i++) {
      pageNumbers.push(
        <li
          key={`page-${i}`}
          className={`page-item${currentPage === i ? " active" : ""}`}
          onClick={() => setCurrentPage(i)}
        >
          <Link to={`/`} className="page-link">
            {i}
          </Link>
        </li>
      );
    }

    // Render the pagination UI with previous, page numbers, and next links
    return (
      <ul className="pagination justify-content-center">
        {/* Previous page link */}
        <li className={`page-item${isFirstPage ? " disabled" : ""}`}>
          <Link
            to={`/`}
            className="page-link"
            onClick={() => setCurrentPage(currentPage - 1)}
          >
            Previous
          </Link>
        </li>

        {/* Render page numbers */}
        {pageNumbers}

        {/* Next page link */}
        <li className={`page-item${isLastPage ? " disabled" : ""}`}>
          <Link
            to={`/`}
            className="page-link"
            onClick={() => setCurrentPage(currentPage + 1)}
          >
            Next
          </Link>
        </li>
      </ul>
    );
  };

  /*
  render() {
    const { totalPages, currentPage, setCurrentPage } = this.props;
    return this.renderPageNumbers(totalPages, currentPage, setCurrentPage);
  }
  */
}

export default Pagination;
