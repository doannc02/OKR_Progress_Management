import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { RoleOfId } from '@/pages/types/role.type';
import { DepartmentView } from '@/pages/types/department.type';
import { Gender } from '@/pages/types/account.type';
import { Controller } from 'react-hook-form';

type Props = {
    control : any,
    label: string
    data:  DepartmentView[] | RoleOfId[] | Gender[]
  }
export default function  SelectFiled({props}: {props: Props}) {
  const [gender,setGender] = React.useState('');
    console.log(props, "xxx")
  const handleChange = (event: SelectChangeEvent) => {
    setGender(event.target.value as string);
    console.log(event.target.value)
  };
console.log(props.control, 'tên control')
  return (
    <Box sx={{ minWidth: 120}}>
     <Controller
     control={props.control}
     name={props.label}
     render={({
        field: { onChange, value, onBlur },
        fieldState: { error },
        formState,
      }) => (
       <>
        <InputLabel id="demo-simple-select-label">{props.label}</InputLabel>
        <Select
         labelId="demo-simple-select-label"
         id="demo-simple-select"
         value={value}
         label={props.label}
        onBlur={onBlur}
         onChange={onChange }
     
       >
         {props.data.map((item: any, i) => {
            <>{error}</>
            if(item?.Name) return <MenuItem key={item.Id} value={item.Id}>{item.Name}</MenuItem>
            else return <MenuItem key={item.Id} value={item.Id}>{item.Role}</MenuItem>
         }            
         )}
       </Select>
       </>

      )}
     />
    </Box>
  );
}

/*
        <FormControl fullWidth height={"12px"}>
        <InputLabel id="demo-simple-select-label">{props.label}</InputLabel>
        <Select
         labelId="demo-simple-select-label"
         id="demo-simple-select"
         value={gender}
         label={props.label}

         onChange={handleChange}
       >
         {props.data.map((item: any, i) => {
            if(item?.Name) return <MenuItem key={item.Id} value={item.Id}>{item.Name}</MenuItem>
            else return <MenuItem key={item.Id} value={item.Id}>{item.Role}</MenuItem>
         }            
         )}
       </Select>
      </FormControl> 
      */