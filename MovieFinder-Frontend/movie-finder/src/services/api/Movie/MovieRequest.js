import MovieSearchDto from "../../dto/MovieSearchDto.js";

import PaginationDto from "../../../services/dto/PaginationDto.js";

import { getAllMovies } from "../../../redux/reducer/api/Movie/MovieSliderAllMovies.jsx";
import { getMovie } from "../../../redux/reducer/api/Movie/MovieSliderGetMovie.jsx";
class MovieRequest {
  getAllMovies = async (currentPage, moviesPerPage, dispatch) => {
    try {
      console.log("GET MOVIE FUNCTION IN USEEFFECT1");
      const paginationDto = new PaginationDto(currentPage, moviesPerPage);
      const response = await dispatch(getAllMovies(paginationDto));
      return response.payload.progress;
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  };
  getMovies = async (name, type, dispatch) => {
    try {
      const movieSearchDto = new MovieSearchDto(name, type);
      const response = await dispatch(getMovie(movieSearchDto));

      return response.payload.progress;
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  };
}

export default MovieRequest;
