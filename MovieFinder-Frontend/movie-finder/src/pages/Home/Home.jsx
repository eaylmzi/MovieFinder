import React, { useState, useEffect } from "react";
import MovieRequest from "../../services/api/Movie/MovieRequest.js";
import MovieViewModel from "../../services/models/ViewModel/Movie/MovieViewModel.js";
import "./Home.css";

import Pagination from "../../services/Pagination/Pagination.jsx";
import MovieInfo from "../../containers/Movie/MovieInfo/MovieInfo.jsx";
import { useDispatch, useSelector } from "react-redux";
// Instantiate movieRequest and pagination objects
const movieRequest = new MovieRequest();
const pagination = new Pagination();

const Home = () => {
  // Define component-level states using useState hooks

  const [currentPage, setCurrentPage] = useState(1); // State to track the current page number
  const [allMovies, setAllMovies] = useState([]);
  const moviesPerPage = 3; // Number of movies to display per page

  const dispatch = useDispatch();
  const { moviesData } = useSelector((store) => store.moviesData);

  useEffect(() => {
    // useEffect hook to fetch movies when currentPage changes
    const fetchMovies = async (currentPage, moviesPerPage) => {
      try {
        console.log("useEffect1 GET REQUEST");
        await movieRequest.getAllMovies(currentPage, moviesPerPage, dispatch);
      } catch (error) {
        console.error("Error fetching movies:", error);
      }
    };
    fetchMovies(currentPage, moviesPerPage);
  }, [currentPage]);

  useEffect(() => {
    // Map fetched movie data to MovieViewModel objects
    console.log("useEffect 222 MAPPING json TO MODEL");
    if (moviesData.data.items.length > 0) {
      const movies = moviesData.data.items.map(
        (movie) => new MovieViewModel(movie)
      );
      setAllMovies(movies);
    }
  }, [moviesData.data.items]);
  return (
    <div className="container">
      <h1>Movie List</h1>
      {moviesData.loading ? ( // Display "Loading..." while data is being fetched
        <div className="loading">Loading...</div>
      ) : (
        <>
          <MovieInfo movieList={allMovies} />
          {pagination.renderPageNumbers(
            moviesData.data.pageCount,
            moviesData.data.currentPage,
            setCurrentPage
          )}
        </>
      )}
    </div>
  );
};

export default Home;
