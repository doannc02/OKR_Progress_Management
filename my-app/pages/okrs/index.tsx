import * as React from "react";
import Stack from "@mui/material/Stack";
import { getMemberListOkr} from "../api/okr.api";
import { useQuery } from "@tanstack/react-query";
import PersistentDrawerLeft from "@/components/main/main";
import { useRouter } from "next/router";
import Cookies from "js-cookie";
import Pagination from "@mui/material/Pagination";
import InputLabel from "@mui/material/InputLabel";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import {
  memberOkr,
} from "../types/okr.type";
import SkeletonOkrs from "@/components/skeleton/skeletonOKRs";
import Search from "./components/searchBar";
import { Button } from "@mui/material";
import GroupQuarterProgress from "../okr/components/GroupQuarterProgress";

const MainOKRs: React.ElementType = () => {
  const [page, setPage] = React.useState(1);
  const [totalRecord, setTotalCounts] = React.useState<number>(10);
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
    setQuery({
      Page: value,
    });
  };
  const [query, setQuery] = React.useState<params>({
    Page: page,
    Email: "",
  });
  // xy ly lay danh sach
  type params = { Page: number | string; Email?: string };

  const handleGetMemberListOkr = async (Page: params) => {
    const res = await getMemberListOkr(Page);
    return res.data;
  };
  const getOKRs = useQuery({
    queryKey: ["listOKR", query],
    queryFn: () => handleGetMemberListOkr(query),
    onSuccess: (data: any) => {
      setTotalCounts(data.TotalCounts);
    },
    onError: (Ex: any) => console.log(Ex),
  });

  return (
      <div
        className="border-2"
        style={{
          overflowY: "hidden",
          width: "100%",
          borderRadius: "4px",
          height: "93.5%",
          position: "relative",
        }}
      >
        <div style={{ height: "100%" }} className="mx-2">
          <Stack
            direction={"row"}
            width={"29%"}
            justifyContent={"space-between"}
            padding={"15px"}
          >
            <label className="mt-2 font-bold">Tìm kiếm theo Email</label>
            <Search
              callback={(query: { Page: number; Email: string }) =>
                setQuery(query)
              }
            />
          </Stack>
          <Stack className="h-full">
            <Stack
              className="overflow-y-scroll"
              height={"88%"}
              border={"1px solid"}
              borderRadius={"4px"}
            >
              <Stack
                paddingLeft={"60px"}
                paddingRight={"10px"}
                width={"100%"}
                direction={"row"}
                justifyContent={"space-between"}
              >
                <div className="font-bold">Họ và tên</div>
                <Stack
                  direction={"row"}
                  width={"35%"}
                  justifyContent={"space-around"}
                >
                  <div className="font-bold">Email</div>
                  <div className="font-bold">Bộ phận</div>
                </Stack>
                <Stack
                  direction={"row"}
                  width={"15%"}
                  justifyContent={"space-around"}
                >
                  <div className="font-bold">Chức vụ</div>
                </Stack>
              </Stack>
              {getOKRs.isLoading ? (
                <SkeletonOkrs />
              ) : (
                getOKRs.data?.Data.map((item: memberOkr) => (
                 <React.Fragment key={item.Id}>
                  <Accordion
                    sx={{
                      border: "1px solid",
                      borderRadius: "4px",
                      margin: "10px",
                    }}
                  >
                    <AccordionSummary
                      expandIcon={<ExpandMoreIcon />}
                      aria-controls="panel1a-content"
                      id="panel1a-header"
                    >
                      <Stack
                        width={"100%"}
                        direction={"row"}
                        justifyContent={"space-between"}
                      >
                        <div>{item.FullName}</div>
                        <Stack
                          direction={"row"}
                          width={"35%"}
                          justifyContent={"space-around"}
                        >
                          <div>{item.Email}</div>
                          <div>{item.DepartmentName}</div>
                        </Stack>
                        <Stack
                          direction={"row"}
                          width={"15%"}
                          justifyContent={"space-around"}
                        >
                          <div
                            className={
                              item.Role === "Developer"
                                ? "border-2 p-1 border-violet-800 w-1/2"
                                : " w-1/2 border-2 p-1 border-red-700"
                            }
                          >
                            {item.Role}
                          </div>
                          {item.AllowCheckIn ? (
                            <Button variant={"contained"} color={"info"}>
                              Check-in
                            </Button>
                          ) : (
                            <Button>&nbsp;</Button>
                          )}
                        </Stack>
                      </Stack>
                    </AccordionSummary>
                    <AccordionDetails
                      sx={{ borderTop: "1px solid", marginBottom: "5px" }}
                    >
                      <div
                        className="border-2"
                        style={{ overflowY: "hidden", width: "100%" }}
                      >
                        <div className="border-b-2">
                          <Stack
                            direction={"row"}
                            justifyContent={"space-between"}
                            sx={{ margin: "1%", borderBottom: "1px solid" }}
                          >
                            <div className="w-1/2 flex justify-center">
                              <InputLabel
                                sx={{
                                  color: "black",
                                  fontWeight: "600",
                                  paddingRight: "35px",
                                }}
                              >
                                Name
                              </InputLabel>
                            </div>
                            <Stack
                              direction="row"
                              spacing={2}
                              justifyContent={"space-around"}
                              width={"50%"}
                            >
                              <div className="w-1/3 flex justify-between">
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý I
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý II
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý III
                                </InputLabel>
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Quý IV
                                </InputLabel>
                              </div>
                              <div className="w-2/3 flex justify-around">
                                <InputLabel
                                  sx={{ color: "black", fontWeight: "600" }}
                                >
                                  Tiến độ
                                </InputLabel>
                              </div>
                            </Stack>
                          </Stack>
                          {item.Objectives.map((objective) => (
                            <React.Fragment key={objective.Id}>
                              {" "}
                              <Stack
                                direction={"row"}
                                justifyContent={"space-between"}
                                sx={{
                                  margin: "1%",
                                  borderBottom: "1px solid",
                                }}
                              >
                                <div className="w-1/2 ml-0">
                                  <InputLabel
                                    sx={{
                                      marginLeft: "5px",
                                      color: "black",
                                      fontWeight: "600",
                                    }}
                                  >
                                    Objective {objective.ObjectiveName}
                                  </InputLabel>
                                </div>
                                <GroupQuarterProgress
                                  props={{
                                    Percent: objective.ObjectivePercent,
                                    isDisableControls: true,
                                  }}
                                />
                              </Stack>
                              {objective.KeyResults.map((kr) => (
                                <React.Fragment key={kr.Id}>
                                  <Stack
                                    direction={"row"}
                                    justifyContent={"space-between"}
                                    sx={{
                                      margin: "1%",
                                      borderBottom: "1px solid",
                                    }}
                                  >
                                    <div className="w-1/2 ml-0">
                                      <InputLabel
                                        sx={{
                                          marginLeft: "20px",
                                          fontWeight: "600",
                                        }}
                                      >
                                        Keyresult {kr.KeyResultName}
                                      </InputLabel>
                                    </div>
                                    <GroupQuarterProgress
                                      props={{
                                        Percent: kr.KeyResultPercent,
                                        dataQuarter: kr.QuarterData,
                                        isDisableControls: true,
                                      }}
                                    />
                                  </Stack>
                                  {kr.KeyResultActions.map((kra) => (
                                    <React.Fragment key={kra.Id}>
                                      <Stack                                       
                                      direction={"row"}
                                      justifyContent={"space-between"}
                                      sx={{
                                        margin: "1%",
                                        borderBottom: "1px solid",
                                      }}
                                    >
                                      <div className="w-1/2 ml-0">
                                        <InputLabel
                                          sx={{
                                            marginLeft: "30px",
                                            fontWeight: "400",
                                          }}
                                        >
                                          Keyresult {kra.ActionName}
                                        </InputLabel>
                                      </div>
                                      <GroupQuarterProgress
                                        props={{
                                          Percent: kra.ActionPercent,
                                          dataQuarter: kra.QuarterData,
                                          isDisableControls: true,
                                        }}
                                      />
                                    </Stack>
                                    </React.Fragment>
                                  ))}
                                </React.Fragment>
                              ))}
                            </React.Fragment>
                          ))}
                        </div>
                      </div>
                    </AccordionDetails>
                  </Accordion>
                 </React.Fragment>
                ))
              )}
            </Stack>
          </Stack>
          <div className="absolute  bottom-1 right-0">
            {" "}
            <Stack justifyContent={"center"} alignItems={"center"} spacing={2}>
              <Pagination
                count={Math.ceil(totalRecord / 10)}
                variant="outlined"
                page={page}
                onChange={handleChange}
              />
            </Stack>
          </div>
        </div>
      </div>
  );
};
export default function CollapsibleTable() {
  const [domLoaded, setDomLoaded] = React.useState(false);
  React.useEffect(() => {
    setDomLoaded(true);
  }, []);

  //main
  if (domLoaded) {
    return <PersistentDrawerLeft title="Danh sách OKR" children={<MainOKRs />} />;
  }
}
