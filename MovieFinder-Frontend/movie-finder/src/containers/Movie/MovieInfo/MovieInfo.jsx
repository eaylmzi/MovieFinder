import React from "react";
import { Link } from "react-router-dom";
const MovieInfo = (movieList) => {
  console.log("MovieInfo COMPONENT");
  return (
    <div className="row">
      {/* Map through movieList and render a card for each movie */}
      {movieList.movieList.map((movie, index) => (
        <div key={`${movie.name}-${index}`} className="card mb-4">
          <div className="d-flex align-items-start">
            {/* Link to the movie detail page */}
            <Link to={`/title/${movie.name}`} state={{ movieData: movie }}>
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
              <Link to={`/title/${movie.name}`} state={{ movieData: movie }}>
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
  );
};

export default MovieInfo;
