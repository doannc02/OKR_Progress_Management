import PersistentDrawerLeft from "@/components/main/main";
import {
  Autocomplete,
  Button,
  Chip,
  Grid,
  InputLabel,
  Stack,
  Typography,
} from "@mui/material";
import ChartLine from "./components/chartLine";
import React from "react";
import CoreAutocomplete from "@/components/CoreAutocomplete";
import { useCheckinPerson } from "@/pages/checkin/components/useCheckinPerson";
import LinearProgressWithLabel from "../home/components/progressbar";
import { convertDate } from "@/helper/date";
import GroupQuarterProgress from "../okr/components/GroupQuarterProgress";
import SkeletonOkrs from "@/components/skeleton/skeletonOKRs";
import CoreInput from "@/components/CoreInput";

const displayStatusOkr = (status: number) => {
  if (status === 1) {
    return "InProgress";
  } else if (status === 4) {
    return "Done";
  }
};

const displayColorKr = (status: number) => {
  if(status === 1) {
    return "info"
  }else if(status === 4){
    return "success"
  }
}

const QuarterData = [
  { label: "Cả năm", value: 0 },
  { label: "Quý I", value: 1 },
  { label: "Quý II", value: 2 },
  { label: "Quý III", value: 3 },
  { label: "Quý IV", value: 4 },
];
const Main: React.ElementType = () => {
  const [values, handles] = useCheckinPerson();
  const { data,totalsKr, isLoading, methodForm, krsUnFinish } = values;

  const { onSubmit, onChangeValue } = handles;
  const { control } = methodForm;
  console.log(data, "checkin");
  return (
        <div
          style={{ borderRadius: "10px", height: "90%" }}
          className="overflow-y-scroll rounded-xl bg-white"
        >
          <div style={{ position: "relative", height: "100vh" }}>
            <Grid container spacing={{ xs: 2 }} zIndex={10000}>
              <Grid item xs={12}>
                <Stack
                  direction={"row"}
                  className="w-full "
                  justifyContent={"space-evenly"}
                >
                  <div className="w-1/2">
                    <Stack
                      direction={"column"}
                      width={"100%"}
                      justifyContent={"center"}
                      alignContent={"space-between"}
                      className="ml-24 my-10"
                    >
                      <form onSubmit={onSubmit}>
                        <Stack
                          direction={"row"}
                          width={"65%"}
                          justifyContent={"center"}
                          alignContent={"center"}
                          className="my-10"
                        >
                          <Typography className="w-1/2" fontWeight={700}>
                            Chọn quý để check-in
                          </Typography>
                          <CoreAutocomplete
                            genus="small"
                            onChangeValue={onChangeValue}
                            defaultValue={0}
                            className="w-1/2"
                            options={QuarterData}
                            valuePath="value"
                            labelPath="label"
                            control={control}
                            name="QuarterId"
                          />
                        </Stack>
                      </form>
                      <div className="w-2/3">
                        <Stack
                          direction={"row"}
                          width={"90%"}
                          justifyContent={"space-between"}
                          alignContent={"center"}
                          className="my-5"
                        >
                          <Typography fontWeight={700}>
                            Ngày cần checkin:
                          </Typography>
                          <Typography>
                            {convertDate(data?.Data?.NextTimeCheckIn) ??
                              Date.now()}
                          </Typography>
                        </Stack>
                        <Stack
                          width={"90%"}
                          justifyContent={"space-between"}
                          alignContent={"center"}
                          direction={"row"}
                          className="my-5"
                        >
                          <Typography fontWeight={700}>Tiến độ OKR:</Typography>

                          <div className="w-[160px]">
                            <LinearProgressWithLabel
                              value={data?.Data?.Okrs[0]?.OKrPercent ?? "0"}
                            />
                          </div>
                        </Stack>
                        <Stack
                          direction={"row"}
                          width={"90%"}
                          justifyContent={"space-between"}
                          alignContent={"center"}
                          className="my-5"
                        >
                          <Typography fontWeight={700}>
                            Trạng thái OKR:
                          </Typography>
                          <Typography>
                            {displayStatusOkr(data?.Data?.Okrs[0]?.Status ?? 0)}
                          </Typography>
                        </Stack>
                        <Stack
                          direction={"row"}
                          width={"90%"}
                          justifyContent={"space-between"}
                          alignContent={"center"}
                        >
                          <Typography fontWeight={700}>
                            Tổng số lần check-in:
                          </Typography>
                          <Typography>
                            {data?.Data?.CountCheckInSchedule}
                          </Typography>
                        </Stack>
                      </div>
                    </Stack>
                  </div>
                  <div className="w-1/2 h-48 mt-10">
                    <div className="flex justify-end mr-10">
                      <Button className="bg-blue-600 mr-5" variant="contained">
                        Hoàn thành OKR
                      </Button>
                      <Button className="bg-blue-600" variant="contained">
                        Lịch sử checkin
                      </Button>
                    </div>
                    <div className="flex justify-center m-5">
                      <ChartLine arrData={data?.Data?.ListCheckInOKr ?? []} />
                    </div>
                  </div>
                </Stack>
              </Grid>
              <Grid item xs={12}>
              {isLoading ? <SkeletonOkrs isDisplayListKr={true}/> : <div className="border-b-2">
                  {data?.Data?.Okrs[0]?.Objectives.map(
                    (objective: any, index: number) => (
                      <React.Fragment key={objective.Id}>
                        {" "}
                        <Stack
                          height={"100px"}
                          direction={"row"}
                          alignContent={"center"}
                          justifyContent={"space-evenly"}
                          sx={{
                            margin: "30px 5px 10px 5px",
                            border: "1px solid #e4e6f6",
                            borderRadius: "10px",
                            backgroundColor: "#A9A9A9",
                            boxShadow:
                              "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06)",
                          }}
                        >
                          <div className="w-1/2 ml-3 my-7 h-3/5">
                            <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "7px",
                                color: "white",
                                fontWeight: "600",
                              }}
                            >
                              Objective {index + 1}: {objective?.ObjectiveName}
                            </Typography>
                          </div>
                          
                          <Stack
                            className="w-2/5 my-10 h-3/"
                            direction={"row"}
                            alignContent={"center"}
                            justifyContent={"space-evenly"}
                          >
                            <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "400",
                              }}
                            >Trạng thái:</Typography>
                            <Chip className="w-2/5" label= {displayStatusOkr(objective?.Status ?? 1)} color={displayColorKr(objective?.Status ?? 1)} />
                          </Stack>

                          <Stack
                            className="w-1/2 my-10 h-3/5"
                            direction={"row"}
                            alignContent={"center"}
                            justifyContent={"space-evenly"}
                          >
                             <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "400",
                              }}
                            >Tiến độ:</Typography>
                            <div className="w-[180px]">
                              <LinearProgressWithLabel
                                value={objective?.ObjectivePercent ?? 0}
                              />
                            </div>
                          </Stack>
                          <Stack
                            className="w-1/3 my-10 h-3/5"
                            direction={"row"}
                            alignContent={"center"}
                            justifyContent={"space-evenly"}
                          >
                            <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "600",
                              }}
                            >Tổng số Krs:</Typography>
                             <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "600",
                              }}
                            >
                             {totalsKr}
                            </Typography>
                          </Stack>
                          <Stack
                            className="w-1/3 my-10 h-3/5"
                            direction={"row"}
                            alignContent={"center"}
                            justifyContent={"space-evenly"}
                          >
                             <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "600",
                              }}
                            >Số Krs đã hoàn thành:</Typography>
                            <Typography
                              aria-multiline
                              sx={{
                                marginLeft: "10px",
                                color: "white",
                                fontWeight: "600",
                              }}
                            >
                            {krsUnFinish}
                            </Typography>
                          </Stack>                                          
                          <div className="flex items-center m-7 w-1/3">
                          <Button className="h-full w-full text-xs bg-blue-500" variant="contained">Hoàn thành Objective</Button>
                          </div>                       
                        </Stack>
                        <Stack
                          direction={"row"}
                          justifyContent={"space-between"}
                          sx={{
                            margin: "1%",
                            borderBottom: "2px solid #e4e6f6",
                          }}
                        >
                          <div className="w-1/2 flex justify-center">
                            <InputLabel
                              sx={{
                                color: "black",
                                fontWeight: "600",
                                paddingRight: "35px",
                              }}
                            >
                              Tên kết quả
                            </InputLabel>
                          </div>
                          <Stack
                            direction="row"
                            spacing={2}
                            justifyContent={"space-around"}
                            width={"50%"}
                          >
                            <div className="w-1/3 flex justify-center">
                              <InputLabel
                                sx={{ color: "black", fontWeight: "600" }}
                              >
                                Mục tiêu
                              </InputLabel>
                             
                            </div>
                            <div className="w-1/3 flex justify-center">
                              <InputLabel
                                sx={{ color: "black", fontWeight: "600" }}
                              >
                                Trạng thái
                              </InputLabel>
                             
                            </div>
                            <div className="w-2/3 flex justify-around">
                              <InputLabel
                                sx={{ color: "black", fontWeight: "600" }}
                              >
                                Tiến độ
                              </InputLabel>
                              <InputLabel
                                sx={{ color: "black", fontWeight: "600" }}
                              >
                                Vấn đề gặp phải
                              </InputLabel>
                            </div>
                          </Stack>
                        </Stack>
                        {objective.KeyResults.map((kr: any, index: number) => (
                          <React.Fragment key={kr.Id}>
                            <Stack
                              direction={"row"} 
                              alignItems={"center"}
                              justifyContent={"space-between"}
                              sx={{
                                margin: "1%",
                                border: "1px solid #e4e6f6",
                              }}
                            >
                              <div className="w-1/2 ml-0 h-full " >
                                <Typography
                                  sx={{
                                    display: 'flex',
                                    alignItems: 'center',
                                    height: "50px",
                                    marginLeft: "5px",
                                    fontWeight: "500",
                                    borderRight: "1px solid #e4e6f6"
                                  }}
                                >
                                  Keyresult {index + 1}: {kr?.KeyResultName}
                                </Typography>
                              </div>
                              <Stack
                            direction="row"
                            spacing={2}
                            justifyContent={"space-around"}
                            width={"50%"}
                          >
                            <div className="w-1/3 flex justify-center" >
                              <InputLabel
                                sx={{ color: "black", fontWeight: "500" }}
                              >
                               100%
                              </InputLabel>
                             
                            </div>
                            <div className="w-1/4 flex justify-center">
                              <InputLabel
                                sx={{ color: "black", fontWeight: "500"}}
                              >
                               <Chip className="w-full" label= {displayStatusOkr(kr?.Status??0)} color={displayColorKr(kr?.Status??0)} />
                              </InputLabel>
                             
                            </div>
                            <div className="w-2/3 flex justify-around" >
                              <InputLabel
                                sx={{ color: "black", fontWeight: "500" }}
                              >
                                {kr?.KeyResultPercent??0}%
                              </InputLabel>
                              <InputLabel
                                sx={{ color: "black", fontWeight: "500" }}
                              >
                                Xem chi tiết
                              </InputLabel>
                            </div>
                          </Stack>
                            </Stack>
                            {kr?.KeyResultActions?.map((kra: any) => (
                              <React.Fragment key={kra?.Id}>
                                <Stack
                                  direction={"row"}
                                  justifyContent={"space-between"}
                                  sx={{
                           
                                    margin: "1%",
                                    borderBottom: "1px solid #e4e6f6",
                                  }}
                                >
                                  <div className="w-1/2 ml-0 h-full">
                                    <InputLabel
                                      sx={{ 
                                        height: "40px",
                                        marginLeft: "30px",
                                        fontWeight: "400",
                                      }}
                                    >
                                      Action: {kra?.ActionName}
                                    </InputLabel>
                                  </div>
                            
                                </Stack>
                              </React.Fragment>
                            ))}
                          </React.Fragment>
                        ))}
                      </React.Fragment>
                    )
                  )}
                </div>}
              </Grid>
              <Grid item xs={12}>
               <Stack className="my-10">
                <div className="flex justify-start ml-10">
                 <Typography fontSize={18} fontWeight={"600"}>
                  Câu hỏi cho quản lý
                  </Typography>                     
                </div>
                <div className="mx-10">
                <CoreInput control={control} name="question" multiline />
                </div>
                <form onSubmit={onSubmit} className="flex justify-end">
                 <Button type="submit" variant="contained" className="bg-yellow-500 m-10">
                  Lưu nháp
                  </Button>                 
                </form>
               </Stack>
              </Grid>
            </Grid>
          </div>
        </div>
  );
};

const CheckinPerson = () => {
  return <PersistentDrawerLeft title="Checkin cá nhân" children={<Main />} />;
};

export default CheckinPerson;
