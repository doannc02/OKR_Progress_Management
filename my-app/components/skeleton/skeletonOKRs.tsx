import * as React from "react";
import Box from "@mui/material/Box";
import Skeleton from "@mui/material/Skeleton";

const SkeletonOkrs = () => {
  const numSkeletons = 10; // Số lượng dòng skeleton

  return  (
        <Box>
  {[...Array(numSkeletons)].map((_, index) => (
    <Skeleton key={index} animation="wave" height="80px" className="m-6"/>
  ))}
</Box>
  )
   
}
export default SkeletonOkrs