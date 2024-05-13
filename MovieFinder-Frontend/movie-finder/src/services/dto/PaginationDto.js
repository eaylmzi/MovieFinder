class PaginationDto {
  constructor(page, pageResult) {
    this.page = page || "";
    this.pageResult = pageResult || "";
  }
}
export default PaginationDto;
