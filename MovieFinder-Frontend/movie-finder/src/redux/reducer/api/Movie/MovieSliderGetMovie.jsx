import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import API_ROUTES from "../../../../config/constants/endpoints/ApiEndpoints";

const initialState = {
  movieData: {
    data: [],
    loading: true,
  },
};
console.log("SLİCERR");
export const getMovie = createAsyncThunk(
  "movie/getMovie",
  async (movieSearchDto) => {
    const response = await axios.post(API_ROUTES.GET_MOVIE, movieSearchDto);
    return response.data;
  }
);
export const movieSlice = createSlice({
  name: "movie",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getMovie.fulfilled, (state, action) => {
      state.movieData.data = action.payload.data;
      state.movieData.loading = false;
    });
    builder.addCase(getMovie.rejected, (state, action) => {
      return {
        loading: true,
      };
    });
  },
});
export const {} = movieSlice.actions;
export default movieSlice.reducer;
