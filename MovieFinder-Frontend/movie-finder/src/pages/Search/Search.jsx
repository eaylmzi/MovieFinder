import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import MovieRequest from "../../services/api/Movie/MovieRequest";
import MovieViewModel from "../../services/models/ViewModel/Movie/MovieViewModel.js";
import SEARCH_TYPE from "../../config/constants/SearchType/SearchType";
import MovieDetailedInfo from "../../containers/Movie/MovieDetailedInfo/MovieDetailedInfo";
import { useDispatch, useSelector } from "react-redux";
const movieRequest = new MovieRequest();
// if route name is not filled, look at this
const Search = () => {
  const { movieName } = useParams();
  const [movieList, setMovieList] = useState([]);
  const [searched, setSearched] = useState(false);

  const dispatch = useDispatch();
  const { movieData } = useSelector((store) => store.movieData);
  useEffect(() => {
    const fetchMovies = async (name) => {
      try {
        await movieRequest.getMovies(name, SEARCH_TYPE.FILM_NAME, dispatch);
      } catch (error) {
        console.error("Error fetching movies:", error);
        setMovieList([]);
      } finally {
        setSearched(true);
      }
    };

    if (movieName) {
      fetchMovies(movieName);
    } else {
      setSearched(false);
      setMovieList([]);
    }
  }, [movieName]);
  useEffect(() => {
    console.log("useEffect 222 MAPPING json TO MODEL");

    if (movieData.data !== null) {
      const movies = movieData.data.map(
        (movieData) => new MovieViewModel(movieData)
      );
      setMovieList(movies);
    } else {
      setMovieList([]);
    }
  }, [movieData.data]);
  return (
    <div className="container">
      <h1>Movie</h1>
      {movieData.loading ? (
        <p>Loading...</p>
      ) : (
        <div className="row">
          {movieList.length > 0 ? (
            movieList.map((movie, index) => (
              <MovieDetailedInfo movieData={movie} index={index} />
            ))
          ) : searched ? (
            <p>No movies found.</p>
          ) : (
            <p>Enter a movie name and click Search.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default Search;
