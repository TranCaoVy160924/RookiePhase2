import React, { useState } from 'react'
import { useInput } from 'react-admin';
import { Box, MenuItem, Select, Typography } from '@mui/material';

function SelectBoxWithFormInside({ data, source, format, parse }) {
    const [addingData, setAddingData] = useState(false)
    const {
        field,
        fieldState: { isTouched, invalid, error },
        formState: { isSubmitted }
    } = useInput({ source, format, parse })

    const handleClick = (e) => {
        setAddingData(true)
    }

    return (
        <Select
            label=""
            {...field}
            sx={{ 
                width:"200px", 
                height:"40px",
                padding:"0px",
                boxSizing:"border-box",
                "& .MuiDataGrid-root": {
                    border: "none",
                },
            }}
        >
            {data.map(item => <MenuItem key={item.id} value={item.id}>{item.name}</MenuItem>)}
            {/* <span style={{ backgroundColor:"gray", width:"200px", height:"2px" }}></span> */}
            <hr style={{ color:"gray" }} />
            <Box>
                <Typography 
                    color="red" 
                    varient="p" 
                    sx={{ 
                        cursor:"pointer", 
                        fontStyle:"italic", 
                        textDecoration:"underline",
                        padding:"6px 16px" 
                    }} 
                    onClick={handleClick}
                >
                    Add new category
                </Typography>
            </Box>
        </Select>
    )
}

export default SelectBoxWithFormInside