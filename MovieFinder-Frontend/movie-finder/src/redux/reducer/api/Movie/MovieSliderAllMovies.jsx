import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import API_ROUTES from "../../../../config/constants/endpoints/ApiEndpoints";

const initialState = {
  moviesData: {
    data: { currentPage: 0, items: [], pageCount: 0, totalItem: 0 },
    loading: true,
  },
};
console.log("SLİCERR");
export const getAllMovies = createAsyncThunk(
  "movie/getAllMovies",
  async (paginationDto) => {
    const response = await axios.post(API_ROUTES.GET_ALL_MOVIE, paginationDto);
    return response.data;
  }
);
export const allMovieSlice = createSlice({
  name: "movie",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAllMovies.fulfilled, (state, action) => {
      state.moviesData.data = action.payload.data;
      state.moviesData.loading = false;
    });
    builder.addCase(getAllMovies.rejected, (state, action) => {
      return {
        loading: true,
      };
    });
  },
});
export const {} = allMovieSlice.actions;
export default allMovieSlice.reducer;
