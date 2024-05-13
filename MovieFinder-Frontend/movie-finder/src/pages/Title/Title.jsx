import React from "react";
import { useLocation } from "react-router-dom";
import MovieDetailedInfo from "../../containers/Movie/MovieDetailedInfo/MovieDetailedInfo";
const Title = () => {
  const location = useLocation();
  const movieData = location.state && location.state.movieData;

  if (!movieData) {
    return <div>Loading...</div>;
  }
  return (
    <div className="container">
      <MovieDetailedInfo movieData={movieData} />
    </div>
  );
};

export default Title;
