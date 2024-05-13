import React from "react";

const MovieDetailedInfo = (movieData, index) => {
  const movie = movieData.movieData;
  if (index === null) {
    index = 1;
  }
  return (
    <div key={index} className="row p-2">
      <div className="card mb-4">
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
            {" "}
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
              {movie.movie_types_name ? movie.movie_types_name.join(", ") : ""}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MovieDetailedInfo;
