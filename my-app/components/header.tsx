import { Stack } from '@mui/material';
import HouseOutlinedIcon from '@mui/icons-material/HouseOutlined';
import Image from 'next/image';
import avatar from '/public/imgs/5ef3b3616722437d4a5e2c49f711d80b.jpg';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import { useRouter } from 'next/router';
import Cookies from 'js-cookie';

export default function Header() {
  const route = useRouter()
  const logout= () => {
    Cookies.remove("Token");
    route.push('/account/login');
  }
  return (
    <Stack
    justifyContent={'space-between'} direction={'row'} bgcolor={'#2e3788'} height={'5vh'}  // Định dạng chung cho padding
    >
      <Stack direction="row" spacing={2} alignItems="center">
        <HouseOutlinedIcon sx={{ color: "#7780d1", height: "80%" }} />
        <p style={{ color: "white" }} >Trang Chủ</p>
      </Stack>
      <Stack direction="row" spacing={2} alignItems="center" height={"100%"}>
        <p style={{ color: "white" }} className="pr-2">system_name</p>
        <Image alt="avatar" src={avatar} className="border-2 rounded-full h-full w-auto m-5  hover:opacity-80 hover:cursor-pointer" />
       <div className={"hover:opacity-80 hover:cursor-pointer"} onClick={logout}>
       <ExitToAppIcon sx={{ color: "#7780d1", height: "100%"}}/>
       </div>
      </Stack>
    </Stack>
  );
}
