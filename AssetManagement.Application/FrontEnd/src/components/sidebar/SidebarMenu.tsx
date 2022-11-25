import { Menu, usePermissions  } from 'react-admin';
import React from 'react';
import { Typography } from '@mui/material';
import PeopleIcon from '@mui/icons-material/People';
import LabelIcon from '@mui/icons-material/Label';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import AssignmentIcon from '@mui/icons-material/Assignment';
import RedoIcon from '@mui/icons-material/Redo';
import PieChartIcon from '@mui/icons-material/PieChart';
import logo from '../../assets/images/logo-transparent.png';
import HomeIcon from '@mui/icons-material/Home';
import { createTheme } from '@mui/material/styles';
import Card from '@mui/material/Card';
const theme = createTheme();

const SidebarMenu = () => {
    const { isLoading, permissions } = usePermissions();
    return(
    <Menu sx={{
        ".css-y07vd-MuiButtonBase-root-MuiMenuItem-root-RaMenuItemLink-root.RaMenuItemLink-active": {
            color: "#fff",
            backgroundColor: '#cf2338',
            fontWeight: "bold",
            ".css-cveggr-MuiListItemIcon-root" :{
                color: "#fff",
            },
            marginBottom: "3px",
        },
        ".css-y07vd-MuiButtonBase-root-MuiMenuItem-root-RaMenuItemLink-root" :{
            color:"#000",
            backgroundColor: "#eff1f5",
            fontWeight: "bold",
            ".css-cveggr-MuiListItemIcon-root" :{
                color: "#000",
            },
            marginBottom: "3px",
        },
    }}>
        <CardMedia
        component="img"
        alt="logo"
        height="auto"
        sx={
            {maxWidth:"100px",
            padding:"5px"
        }
        }
        image={logo}
        />
        <Typography textAlign="center" variant="h3" component="h2" color="secondary" fontSize='1rem' fontWeight="bold" className="appTitleMenuBar" mb={3}>Online Asset Management</Typography>
        <Menu.Item to="/home" primaryText="Home" leftIcon={<HomeIcon/>}/>
            {permissions === 'Admin' ?<Menu.Item to="/users" primaryText="Manage User" leftIcon={<PeopleIcon/>}/>:null }
            {permissions === 'Admin' ?<Menu.Item to="/assets" primaryText="Manage Asset" leftIcon={<LabelIcon/>}/>:null }
            {permissions === 'Admin' ?<Menu.Item to="/assignments" primaryText="Manage Assignment" leftIcon={<AssignmentIcon/>}/>:null  }
            {permissions === 'Admin' ?<Menu.Item to="/returning" primaryText="Request for Returning" leftIcon={<RedoIcon/>}/>:null  }
            {permissions === 'Admin' ?<Menu.Item to="/report" primaryText="Report" leftIcon={<PieChartIcon/>}/>:null}
    </Menu >
    )
};

export default SidebarMenu;