import React, {useState, useEffect} from 'react';
import { AppBar, UserMenu, useShowContext, Button } from 'react-admin';
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';
import Typography from '@mui/material/Typography';


const Header = () => {
    const [userName, setUserName] = useState(localStorage.getItem('userName') || '' )
    useEffect(() => {
        setUserName(localStorage.getItem('userName') || '')
    })
    const button = <Button color="inherit" endIcon={<ArrowDropDownIcon/>} label={userName} sx={{
        textTransform: "none",  
        font: "20px Roboto,Helvetica,Arial,sans-serif",
        fontWeight: "bold"
    }}/>
    return(
    <AppBar
        userMenu={<UserMenu icon={button}/>}
        open={false}
        sx= {{
            color:"white",
            padding: "5px 10px",
            // ".RaAppBar-menuButton" : {
            //     display: "none"
            // },
            ".RaLoadingIndicator-root": {
                display:"none"
            },
            ".RaLoadingIndicator-loadedIcon": {
                display:"none"
            },
            ".RaAppBar-title": {
                paddingLeft: "10px",
                fontWeight: "bold"
            }
        }}
    />
    )
};

export default Header;