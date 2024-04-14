import API_ROUTES from "../../constants/endpoints/ApiEndpoints";
import MovieSearchDto from "../../Dto/MovieSearchDto.js";
import axios from "axios";

class MovieRequest {
  getAllMovies = async (paginationDto) => {
    try {
      const response = await axios.post(
        API_ROUTES.GET_ALL_MOVIE,
        paginationDto
      );
      console.log(response.data);
      return response.data;
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  };
  getMovies = async (name, type) => {
    try {
      const movieSearchDto = new MovieSearchDto(name, type);
      const response = await axios.post(API_ROUTES.GET_MOVIE, movieSearchDto);
      console.log(response.data);
      return response.data;
    } catch (error) {
      console.error("Error fetching posts:", error);
    }
  };
}

export default MovieRequest;
