import { configureStore } from "@reduxjs/toolkit";
import allMovieReducer from "../reducer/api/Movie/MovieSliderAllMovies";
import movieReducer from "../reducer/api/Movie/MovieSliderGetMovie";
export const store = configureStore({
  reducer: {
    moviesData: allMovieReducer,
    movieData: movieReducer,
  },
});
