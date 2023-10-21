import React from "react";
import { Table } from "@mui/material";

const data = [
  { No: 1, Name: "Đào Hồng Hải", Role: "JQC", Team: "RV1", Star: 34 },
  { No: 2, Name: "Dương Trung Đạt", Role: "JQC", Team: "RV1", Star: 33 },
  { No: 3, Name: "Đỗ Thị Huyền", Role: "JQC", Team: "RV1", Star: 33 },
  { No: 4, Name: "Bùi Thị Thuỷ", Role: "JQC", Team: "RV1", Star: 32 },
  { No: 5, Name: "Cấn Thị Mai Hương", Role: "JQC", Team: "RV1", Star: 32 },
  { No: 6, Name: "Vũ Thị Minh Thuý", Role: "JQC", Team: "Shōgaisha", Star: 31 },
  { No: 7, Name: "Bùi Thị Mai Anh", Role: "JQC", Team: "RV1", Star: 30 },
  { No: 8, Name: "Đỗ Văn Tú", Role: "JQC", Team: "RV1", Star: 28 },
  { No: 9, Name: "Trần Đức Trung", Role: "JQC", Team: "RV1", Star: 28 },
  { No: 10, Name: "Trần Thị Trâm", Role: "JQC", Team: "RV1", Star: 27 },
];

import { styled } from '@mui/material/styles';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
   
    color: theme.palette.common.black,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

function createData(
  name: string,
  calories: number,
  fat: number,
  carbs: number,
  protein: number,
) {
  return { name, calories, fat, carbs, protein };
}

export default function CustomizedTables() {
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 700 }} aria-label="customized table">
        <TableHead>
          <TableRow >
            <StyledTableCell align="right">STT</StyledTableCell>
            
            <StyledTableCell align="right">Họ Và Tên</StyledTableCell>
            <StyledTableCell align="right">Vị Trí</StyledTableCell>
            <StyledTableCell align="right">Phòng Ban</StyledTableCell>
            <StyledTableCell align="right">Số Sao</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <StyledTableRow key={row.No} className="scroll">
                <StyledTableCell align="right">{row.No}</StyledTableCell>
              <StyledTableCell align="right" component="th" scope="row">
                {row.Name}
              </StyledTableCell>
              <StyledTableCell align="right">{row.Role}</StyledTableCell>
              <StyledTableCell align="right">{row.Team}</StyledTableCell>
              <StyledTableCell align="right">{row.Star}</StyledTableCell>
              
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
