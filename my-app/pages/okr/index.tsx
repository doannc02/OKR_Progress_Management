import * as React from "react";
import Box from "@mui/material/Box";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import DeleteIcon from "@mui/icons-material/Delete";
import SendIcon from "@mui/icons-material/Send";
import AddIcon from "@mui/icons-material/Add";
import { IUser } from "../types/user.type";
import dynamic from "next/dynamic";
import Cookies from "js-cookie";
import { useRouter } from "next/router";
import PersistentDrawerLeft from "@/components/main/main";
import { InputLabel, Paper, styled } from "@mui/material";
import SelectFiled from "../account/component/selectField";
import { Gender } from "../types/account.type";
import { useForm } from "react-hook-form";
import z from "zod";
import LinearProgressWithLabel from "../home/components/progressbar";
import Add from "@mui/icons-material/Add";
import Edit from "@mui/icons-material/Edit";
//data fake
const dataFakeOkr = [
  {
    Id: 110,
    OkrName: "OKR năm 2023",
    OKrPercent: 55,
    OkrType: null,
    OkrStatus: 1,
    UserId: 52,
    FullName: "Nguyễn Đình Hiếu",
    Email: "hieund@ominext.com",
    Avatar: null,
    Role: "Developer",
    UserRoleName: null,
    DepartmentId: 8,
    DepartmentName: "Mell",
    AllowCheckIn: false,
    IsManager: false,
    DepartmentStructure: null,
    Objectives: [
      {
        Id: 363,
        OkrId: 110,
        UserId: 52,
        OkrName: "OKR năm 2023",
        ObjectiveName: "Đảm bảo tiến độ và chất lượng dự án",
        ObjectivePercent: 100,
        ObjectiveType: 1,
        Status: 4,
        KeyResults: [
          {
            Id: 1083,
            ObjectiveId: 363,
            UserId: 52,
            KeyResultName: "90% các task được giao đến khách đúng hạn",
            KeyResultPercent: 100,
            QuarterId: 1,
            QuarterName: null,
            QuarterData: "2,3,4,1",
            KeyResultActions: [
              {
                Id: 594,
                KeyResultId: 1083,
                UserId: 52,
                KeyResultName: "90% các task được giao đến khách đúng hạn",
                ActionName: "Clear task trước khi được giao",
                ActionPercent: 0,
                QuarterId: 1,
                QuarterName: null,
                QuarterData: "2,3,4,1",
              },
              {
                Id: 595,
                KeyResultId: 1083,
                UserId: 52,
                KeyResultName: "90% các task được giao đến khách đúng hạn",
                ActionName: "Thực hiện estimate sau khi đã clear thông tin",
                ActionPercent: 0,
                QuarterId: 1,
                QuarterName: null,
                QuarterData: "2,3,4,1",
              },
              {
                Id: 596,
                KeyResultId: 1083,
                UserId: 52,
                KeyResultName: "90% các task được giao đến khách đúng hạn",
                ActionName:
                  "Thực hiện việc check tiến độ của bản thân hàng ngày",
                ActionPercent: 0,
                QuarterId: 1,
                QuarterName: null,
                QuarterData: "2,3,4,1",
              },
            ],
          },
          {
            Id: 1086,
            ObjectiveId: 363,
            UserId: 52,
            KeyResultName: "Số comment nhận từ khách không quá 5 comment",
            KeyResultPercent: 100,
            QuarterId: 1,
            QuarterName: null,
            QuarterData: "2,3,4,1",
            KeyResultActions: [
              {
                Id: 663,
                KeyResultId: 1086,
                UserId: 52,
                KeyResultName: "Số comment nhận từ khách không quá 5 comment",
                ActionName:
                  "Kiểm tra lại task đã thực hiện trước khi thực hiện review code nội bộ",
                ActionPercent: 0,
                QuarterId: 1,
                QuarterName: null,
                QuarterData: "2,3,4,1",
              },
              {
                Id: 664,
                KeyResultId: 1086,
                UserId: 52,
                KeyResultName: "Số comment nhận từ khách không quá 5 comment",
                ActionName:
                  "Nhận được review từ member trong team cũng như PM trước khi được khách review code",
                ActionPercent: 0,
                QuarterId: 1,
                QuarterName: null,
                QuarterData: "2,3,4,1",
              },
            ],
          },
        ],
      },
      {
        Id: 365,
        OkrId: 110,
        UserId: 52,
        OkrName: "OKR năm 2023",
        ObjectiveName: "Nâng cao kiến thức về Y tế số",
        ObjectivePercent: 0,
        ObjectiveType: 1,
        Status: 1,
        KeyResults: [
          {
            Id: 1089,
            ObjectiveId: 365,
            UserId: 52,
            KeyResultName:
              "Pass 100% các bài kiểm tra về Y tế số trong hệ thống E learning",
            KeyResultPercent: 0,
            QuarterId: 2,
            QuarterName: null,
            QuarterData: "3,4",
            KeyResultActions: [],
          },
          {
            Id: 1090,
            ObjectiveId: 365,
            UserId: 52,
            KeyResultName:
              "Thực hiện được 1 document về kiến thức Y tế số đã tìm hiểu được",
            KeyResultPercent: 0,
            QuarterId: 2,
            QuarterName: null,
            QuarterData: "3,4",
            KeyResultActions: [
              {
                Id: 607,
                KeyResultId: 1090,
                UserId: 52,
                KeyResultName:
                  "Thực hiện được 1 document về kiến thức Y tế số đã tìm hiểu được",
                ActionName:
                  "Thực hiện việc tìm hiểu các kiến thức thông qua các nguồn tài liệu uy tín",
                ActionPercent: 0,
                QuarterId: 2,
                QuarterName: null,
                QuarterData: "3,4",
              },
              {
                Id: 609,
                KeyResultId: 1090,
                UserId: 52,
                KeyResultName:
                  "Thực hiện được 1 document về kiến thức Y tế số đã tìm hiểu được",
                ActionName:
                  "Tóm tắt các kiến thức đã tìm hiểu được thành 1 document hoàn chỉnh",
                ActionPercent: 0,
                QuarterId: 2,
                QuarterName: null,
                QuarterData: "3,4",
              },
            ],
          },
        ],
      },
      {
        Id: 366,
        OkrId: 110,
        UserId: 52,
        OkrName: "OKR năm 2023",
        ObjectiveName:
          "Phát triển bản thân và học các ngôn ngữ mới phục vụ cho dự án",
        ObjectivePercent: 25,
        ObjectiveType: 1,
        Status: 1,
        KeyResults: [
          {
            Id: 1092,
            ObjectiveId: 366,
            UserId: 52,
            KeyResultName:
              "Nâng cao khả năng thuyết trình thông qua việc hoàn thành 10 bài luận và thực hiện 6 seminar",
            KeyResultPercent: 0,
            QuarterId: 4,
            QuarterName: null,
            QuarterData: "3,4",
            KeyResultActions: [
              {
                Id: 611,
                KeyResultId: 1092,
                UserId: 52,
                KeyResultName:
                  "Nâng cao khả năng thuyết trình thông qua việc hoàn thành 10 bài luận và thực hiện 6 seminar",
                ActionName:
                  "Xác định các chủ đề dự định thực hiện seminar ( hướng đến phục vụ cho dự án)",
                ActionPercent: 0,
                QuarterId: 4,
                QuarterName: null,
                QuarterData: "3,4",
              },
              {
                Id: 612,
                KeyResultId: 1092,
                UserId: 52,
                KeyResultName:
                  "Nâng cao khả năng thuyết trình thông qua việc hoàn thành 10 bài luận và thực hiện 6 seminar",
                ActionName:
                  "Thực hiện bài luận cũng như seminar và xin sự góp ý từ quản lý và các member trong team",
                ActionPercent: 0,
                QuarterId: 4,
                QuarterName: null,
                QuarterData: "3,4",
              },
            ],
          },
          {
            Id: 1093,
            ObjectiveId: 366,
            UserId: 52,
            KeyResultName:
              "Thực hiện được 1 documnet về nội dung cơ bản của .net",
            KeyResultPercent: 40,
            QuarterId: 2,
            QuarterName: null,
            QuarterData: "1,2",
            KeyResultActions: [
              {
                Id: 613,
                KeyResultId: 1093,
                UserId: 52,
                KeyResultName:
                  "Thực hiện được 1 documnet về nội dung cơ bản của .net",
                ActionName:
                  "Tìm hiểu syntax cơ bản của .Net dành 3 tiếng (0.5h/ngày)",
                ActionPercent: 0,
                QuarterId: 2,
                QuarterName: null,
                QuarterData: "1,2",
              },
              {
                Id: 619,
                KeyResultId: 1093,
                UserId: 52,
                KeyResultName:
                  "Thực hiện được 1 documnet về nội dung cơ bản của .net",
                ActionName: "Tìm hiểu OOP dành 24h (0.5h/ngày)",
                ActionPercent: 0,
                QuarterId: 2,
                QuarterName: null,
                QuarterData: "1,2",
              },
              {
                Id: 629,
                KeyResultId: 1093,
                UserId: 52,
                KeyResultName:
                  "Thực hiện được 1 documnet về nội dung cơ bản của .net",
                ActionName:
                  "Tìm hiểu về design patern Unit Of Work trong 8h (0.5h/ngày)",
                ActionPercent: 0,
                QuarterId: 2,
                QuarterName: null,
                QuarterData: "1,2",
              },
            ],
          },
          {
            Id: 1097,
            ObjectiveId: 366,
            UserId: 52,
            KeyResultName: "Thực hiện 1 document về kiến thức cơ bản trong PHP",
            KeyResultPercent: 45,
            QuarterId: 3,
            QuarterName: null,
            QuarterData: "2,3",
            KeyResultActions: [
              {
                Id: 630,
                KeyResultId: 1097,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong PHP",
                ActionName: "Tìm hiểu OOP của PHP dành 5h (0.5h/ngày)",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
              {
                Id: 631,
                KeyResultId: 1097,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong PHP",
                ActionName:
                  "Tìm hiểu Framework Laravel dành 24h ( 0.75h mỗi ngày)        ",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
              {
                Id: 632,
                KeyResultId: 1097,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong PHP",
                ActionName:
                  "Các cách Framework Laravel kết nối với các DB khác nhau dành 16h (0.5h/ngày)",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
            ],
          },
          {
            Id: 1098,
            ObjectiveId: 366,
            UserId: 52,
            KeyResultName:
              "Thực hiện 1 document về kiến thức cơ bản trong MongoDb",
            KeyResultPercent: 15,
            QuarterId: 3,
            QuarterName: null,
            QuarterData: "2,3",
            KeyResultActions: [
              {
                Id: 633,
                KeyResultId: 1098,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong MongoDb",
                ActionName:
                  "Dành 10h (0.5h mỗi ngày) tìm hiểu syntax, kiểu dữ liệu của MongoDB",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
              {
                Id: 634,
                KeyResultId: 1098,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong MongoDb",
                ActionName: "Tìm hiểu về ưu và nhược điểm của MongoDB",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
              {
                Id: 635,
                KeyResultId: 1098,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong MongoDb",
                ActionName: "Dành 24h (0.5h/ngày) tìm hiểu về NoSQL",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
              {
                Id: 665,
                KeyResultId: 1098,
                UserId: 52,
                KeyResultName:
                  "Thực hiện 1 document về kiến thức cơ bản trong MongoDb",
                ActionName:
                  "Dành 6h (0.5h/ngày) tìm hiểu cách find dữ liệu trong MongoDB",
                ActionPercent: 0,
                QuarterId: 3,
                QuarterName: null,
                QuarterData: "2,3",
              },
            ],
          },
        ],
      },
      {
        Id: 367,
        OkrId: 110,
        UserId: 52,
        OkrName: "OKR năm 2023",
        ObjectiveName: "Hoàn thành các chức năng cốt lõi của dự án OKEA",
        ObjectivePercent: 95,
        ObjectiveType: 1,
        Status: 4,
        KeyResults: [
          {
            Id: 1099,
            ObjectiveId: 367,
            UserId: 52,
            KeyResultName: "100% chức năng đúng nghiệp vụ",
            KeyResultPercent: 100,
            QuarterId: 3,
            QuarterName: null,
            QuarterData: "1,2,3",
            KeyResultActions: [],
          },
          {
            Id: 1100,
            ObjectiveId: 367,
            UserId: 52,
            KeyResultName: "Chỉ số Response trung bình của 1 page là dưới 3s",
            KeyResultPercent: 80,
            QuarterId: 0,
            QuarterName: null,
            QuarterData: "1,2,3",
            KeyResultActions: [],
          },
          {
            Id: 1101,
            ObjectiveId: 367,
            UserId: 52,
            KeyResultName: "Hoàn thành các task đúng hạn 31/3",
            KeyResultPercent: 100,
            QuarterId: 3,
            QuarterName: null,
            QuarterData: "1,2,3",
            KeyResultActions: [],
          },
          {
            Id: 1102,
            ObjectiveId: 367,
            UserId: 52,
            KeyResultName: "Tổng bug <=3",
            KeyResultPercent: 100,
            QuarterId: 3,
            QuarterName: null,
            QuarterData: "1,2,3",
            KeyResultActions: [],
          },
        ],
      },
    ],
  },
];

// chart rank
export default function Okr() {
  const dtProgress = [
    {
      label: "nameA",
      value: 10,
    },
  ];
  // valid
  const schema = z.object({
    Select_MyOKR: z
      .string()
      .nonempty("Trường này là bắt buộc!")
      .email("Không đúng định dạng Email!"),
    password: z
      .string()
      .nonempty("Trường này là bắt buộc!")
      .refine((value) => value.length >= 6, "Mật khẩu tối thiểu 6 kí tự"),
  });
  const {
    handleSubmit,
    formState: { errors },
    control,
  } = useForm({
    defaultValues: {},
  });
  //Item
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
  }));

  const [domLoaded, setDomLoaded] = React.useState(false);
  const [data, setData] = React.useState<IUser>();
  const router = useRouter();
  const isAuthenticated =
    typeof window !== "undefined" && !!Cookies.get("Token");

  React.useEffect(() => {
    setDomLoaded(true);
    if (!isAuthenticated) {
      router.push("/account/login");
    }
  }, [isAuthenticated, router]);

  const boxShadowStyle = {
    borderRadius: "10px",
    margin: "3%",
    height: "60vh",
    padding: "20px",
    boxShadow: "10px 10px 10px 10px rgba(0.2, 0.2, 0.2, 0.2)",
    background: "white",
  };

  const MainOKR: React.ElementType = () => {
    const dtOKRSelect: Gender[] = [
      { Name: "Okr", Id: 1 },
      { Name: " OKr2", Id: 2 },
    ];
    return (
      <>
        {dataFakeOkr.map((item) => (
          <div
            className="border-2"
            style={{ overflowY: "hidden", width: "100%" }}
          >
            <div className="border-b-2">
              <Stack
                direction={"row"}
                justifyContent={"space-between"}
                sx={{ margin: "3%" }}
              >
                <div className="w-1/2">
                  <SelectFiled
                    props={{
                      data: dtOKRSelect,
                      label: "Select_MyOKR",
                      control: control,
                    }}
                  />
                </div>
                <Stack direction="row" spacing={2}>
                  <Button variant="outlined" startIcon={<Add />}>
                    Add
                  </Button>
                  <Button
                    variant="outlined"
                    color="warning"
                    startIcon={<Edit />}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outlined"
                    color="error"
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                  <Button variant="contained" endIcon={<SendIcon />}>
                    Xét duyệt
                  </Button>
                </Stack>
              </Stack>
            </div>

            <div className="border-b-2">
              <Stack
                direction={"row"}
                justifyContent={"space-between"}
                sx={{ margin: "3%" }}
              >
                <div className="w-1/2">
                  <SelectFiled
                    props={{
                      data: dtOKRSelect,
                      label: "Select_MyOKR",
                      control: control,
                    }}
                  />
                </div>
              </Stack>
              <Stack
                direction={"row"}
                justifyContent={"space-between"}
                sx={{ margin: "3%" }}
              >
                <Stack direction="row" spacing={2}>
                  <InputLabel
                    sx={{
                      color: "black",
                      fontWeight: "600",
                      paddingRight: "35px",
                    }}
                  >
                    Chu kì: Quý 1
                  </InputLabel>
                  <InputLabel
                    sx={{
                      color: "black",
                      fontWeight: "600",
                      paddingRight: "35px",
                    }}
                  >
                    Ngày bắt đầu: 01-01-2023
                  </InputLabel>
                  <InputLabel
                    sx={{
                      color: "black",
                      fontWeight: "600",
                      paddingRight: "35px",
                    }}
                  >
                    Ngày kết thúc: 31-03-2023
                  </InputLabel>
                  <InputLabel
                    sx={{
                      color: "black",
                      fontWeight: "600",
                      paddingRight: "35px",
                    }}
                  >
                    Số ngày còn lại: 30/90
                  </InputLabel>
                </Stack>
              </Stack>
              <Stack
                direction={"row"}
                justifyContent={"space-between"}
                sx={{ margin: "3%" }}
              >
                <Stack direction="row" spacing={2} width={"100vw"}>
                  <InputLabel sx={{ width: "30% " }}>
                    Tiến trình thời gian <LinearProgressWithLabel value={30} />{" "}
                  </InputLabel>
                  <InputLabel sx={{ width: "30% " }}>
                    Kết quả <LinearProgressWithLabel value={item.OKrPercent} />
                  </InputLabel>
                </Stack>
              </Stack>
            </div>

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
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Quý I
                    </InputLabel>
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Quý II
                    </InputLabel>
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Quý III
                    </InputLabel>
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Quý IV
                    </InputLabel>
                  </div>
                  <div className="w-2/3 flex justify-around">
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Tiến độ
                    </InputLabel>
                    <InputLabel sx={{ color: "black", fontWeight: "600" }}>
                      Thao tác
                    </InputLabel>
                  </div>
                </Stack>
              </Stack>
              {item.Objectives.map((objective) => (
              <> <Stack
                  direction={"row"}
                  justifyContent={"space-between"}
                  sx={{ margin: "1%", borderBottom: "1px solid" }}
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
                  <Stack
                    direction="row"
                    spacing={2}
                    justifyContent={"space-around"}
                    width={"50%"}
                  >
                    <div className="w-1/3 flex justify-between">
                      <InputLabel>v</InputLabel>
                      <InputLabel>v</InputLabel>
                      <InputLabel>v</InputLabel>
                      <InputLabel>v</InputLabel>
                    </div>
                    <div className="w-2/3 flex justify-around">
                      <div className="w-1/3">
                        <LinearProgressWithLabel
                          value={objective.ObjectivePercent}
                        />
                      </div>
                      <InputLabel>Thao tác</InputLabel>
                    </div>
                  </Stack>
                 
                </Stack>
                {
                    objective.KeyResults.map(kr => (
                       <>
                        <Stack
                        direction={"row"}
                        justifyContent={"space-between"}
                        sx={{ margin: "1%", borderBottom: "1px solid" }}
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
                        <Stack
                          direction="row"
                          spacing={2}
                          justifyContent={"space-around"}
                          width={"50%"}
                        >
                          <div className="w-1/3 flex justify-between">
                            <InputLabel>v</InputLabel>
                            <InputLabel>v</InputLabel>
                            <InputLabel>v</InputLabel>
                            <InputLabel>v</InputLabel>
                          </div>
                          <div className="w-2/3 flex justify-around">
                            <div className="w-1/3">
                              <LinearProgressWithLabel
                                value={kr.KeyResultPercent}
                              />
                            </div>
                            <InputLabel>Thao tác</InputLabel>
                          </div>
                        </Stack>
                      </Stack>
                      {
                        kr.KeyResultActions.map(kra => (
                            <Stack
                            direction={"row"}
                            justifyContent={"space-between"}
                            sx={{ margin: "1%", borderBottom: "1px solid" }}
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
                            <Stack
                              direction="row"
                              spacing={2}
                              justifyContent={"space-around"}
                              width={"50%"}
                            >
                              <div className="w-1/3 flex justify-between">
                                <InputLabel>v</InputLabel>
                                <InputLabel>v</InputLabel>
                                <InputLabel>v</InputLabel>
                                <InputLabel>v</InputLabel>
                              </div>
                              <div className="w-2/3 flex justify-around">
                                <div className="w-1/3">
                                  <LinearProgressWithLabel
                                    value={kra.ActionPercent}
                                  />
                                </div>
                                <InputLabel>Thao tác</InputLabel>
                              </div>
                            </Stack>
                          </Stack>
                        ))
                      }
                      </>
                    ))
                  }
              </>
              ))}
            </div>
          </div>
        ))}
      </>
    );
  };
  if (isAuthenticated && domLoaded) {
    return <PersistentDrawerLeft title={"OKR"} children={<MainOKR />} />;
  }
}
