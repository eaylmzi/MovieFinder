import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import MovieRequest from "../../../functions/Movie/MovieRequest";
import MovieViewModel from "../../../models/Movie/MovieViewModel";
import SEARCH_TYPE from "../../../constants/SearchType/SearchType";

const movieRequest = new MovieRequest();

const Search = () => {
  const { movieName } = useParams();
  const [movieList, setMovieList] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searched, setSearched] = useState(false);

  useEffect(() => {
    const fetchMovies = async (name) => {
      setLoading(true); // Yükleniyor durumunu başlat

      try {
        const response = await movieRequest.getMovies(
          name,
          SEARCH_TYPE.FILM_NAME
        );
        if (response.data !== null) {
          const movies = response.data.map(
            (movieData) => new MovieViewModel(movieData)
          );
          setMovieList(movies);
        } else {
          setMovieList([]);
        }
      } catch (error) {
        console.error("Error fetching movies:", error);
        setMovieList([]);
      } finally {
        setLoading(false);
        setSearched(true);
      }
    };

    if (movieName) {
      fetchMovies(movieName);
    } else {
      setMovieList([]);
    }
  }, [movieName]);

  return (
    <div className="container">
      <h1>Movie</h1>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <div className="row">
          {movieList.length > 0 ? (
            movieList.map((movie, index) => (
              <div key={index} className="card mb-4">
                <div className="d-flex align-items-start">
                  <img
                    src={`data:image/jpeg;base64,${movie.poster}`}
                    className="p-2"
                    alt={movie.name}
                    style={{
                      height: "330px",
                      width: "auto",
                    }}
                  />
                  <div className="p-3 ml-3">
                    <h5>{movie.name}</h5>
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
                    <p className="card-text">
                      <strong>Director:</strong> {movie.director_name}
                    </p>
                    <p className="card-text">
                      <strong>Writers:</strong>{" "}
                      {movie.writers_name ? movie.writers_name.join(", ") : ""}
                    </p>
                    <p className="card-text">
                      <strong>Stars:</strong>{" "}
                      {movie.stars_name ? movie.stars_name.join(", ") : ""}
                    </p>
                    <p className="card-text">
                      <strong>Genres:</strong>{" "}
                      {movie.movie_types_name
                        ? movie.movie_types_name.join(", ")
                        : ""}
                    </p>
                  </div>
                </div>
              </div>
            ))
          ) : searched ? ( // Arama yapıldıysa ve film bulunamadıysa
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
