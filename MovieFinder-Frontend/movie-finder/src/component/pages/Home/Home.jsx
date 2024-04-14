import React, { useState, useEffect } from "react";
import MovieRequest from "../../../functions/Movie/MovieRequest.js";
import MovieViewModel from "../../../models/Movie/MovieViewModel.js";
import "./Home.css";
import { Link } from "react-router-dom";
import PaginationDto from "../../../Dto/PaginationDto.js";
import Pagination from "../../../functions/Pagination/Pagination.jsx";

// Instantiate movieRequest and pagination objects
const movieRequest = new MovieRequest();
const pagination = new Pagination();

const Home = () => {
  // Define component-level states using useState hooks
  const [movieList, setMovieList] = useState([]); // State to hold the list of movies
  const [totalItem, setTotalItem] = useState(0); // State to hold the total number of movies
  const [currentPage, setCurrentPage] = useState(1); // State to track the current page number
  const [isLoading, setIsLoading] = useState(true); // State to manage loading status
  const moviesPerPage = 3; // Number of movies to display per page
  const totalPages = Math.ceil(totalItem / moviesPerPage); // Calculate total number of pages based on totalItem

  useEffect(() => {
    // useEffect hook to fetch movies when currentPage changes
    const fetchMovies = async (paginationDto) => {
      try {
        // Fetch movies from the API using movieRequest
        const response = await movieRequest.getAllMovies(paginationDto);
        // Map fetched movie data to MovieViewModel objects
        const movies = response.data.items.map(
          (movieData) => new MovieViewModel(movieData)
        );
        // Update movieList and totalItem states with fetched data
        setMovieList(movies);
        setTotalItem(response.data.totalItem);
        setIsLoading(false); // Set isLoading to false when data is successfully loaded
      } catch (error) {
        console.error("Error fetching movies:", error);
        setIsLoading(false); // Set isLoading to false if there's an error during data fetch
      }
    };

    // Create a pagination DTO (Data Transfer Object) based on currentPage and moviesPerPage
    const paginationDto = new PaginationDto(currentPage, moviesPerPage);
    setIsLoading(true); // Set isLoading to true when starting to fetch data
    fetchMovies(paginationDto); // Call fetchMovies function with the pagination DTO
  }, [currentPage]); // useEffect runs whenever currentPage changes

  return (
    <div className="container">
      <h1>Movie List</h1>
      {isLoading ? ( // Display "Loading..." while data is being fetched
        <div className="loading">Loading...</div>
      ) : (
        // Render movie cards and pagination when data is loaded
        <>
          <div className="row">
            {/* Map through movieList and render a card for each movie */}
            {movieList.map((movie, index) => (
              <div key={`${movie.name}-${index}`} className="card mb-4">
                <div className="d-flex align-items-start">
                  {/* Link to the movie detail page */}
                  <Link
                    to={`/title/${movie.name}`}
                    state={{ movieData: movie }}
                  >
                    {/* Display movie poster */}
                    <img
                      src={`data:image/jpeg;base64,${movie.poster}`}
                      className="p-2 image-hover-effect"
                      alt={movie.name}
                      style={{ maxHeight: "200px" }}
                    />
                  </Link>

                  <div className="p-3 ml-3">
                    {/* Link to the movie detail page */}
                    <Link
                      to={`/title/${movie.name}`}
                      state={{ movieData: movie }}
                    >
                      <h5>{movie.name}</h5>
                    </Link>
                    {/* Display movie year, duration, IMDb rating, and description */}
                    <p className="mb-2">
                      <strong>Year:</strong> {movie.year}
                    </p>
                    <p className="mb-2">
                      <strong>Duration:</strong> {movie.duration} minutes
                    </p>
                    <p className="mb-2">
                      <strong>IMDb Rating:</strong> {movie.point}
                    </p>
                    <p className="mb-0">{movie.description}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>

          {/* Render pagination component */}
          {pagination.renderPageNumbers(
            totalPages,
            currentPage,
            setCurrentPage
          )}
        </>
      )}
    </div>
  );
};

export default Home;
