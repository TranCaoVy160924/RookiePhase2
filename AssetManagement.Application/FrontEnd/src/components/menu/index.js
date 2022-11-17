import { Menu, Labeled } from 'react-admin';
import React from 'react';
import { Typography } from '@mui/material';
import BookIcon from '@mui/icons-material/Book';
import ChatBubbleIcon from '@mui/icons-material/ChatBubble';
import PeopleIcon from '@mui/icons-material/People';
import LabelIcon from '@mui/icons-material/Label';
import AssignmentIcon from '@mui/icons-material/Assignment';
import RedoIcon from '@mui/icons-material/Redo';
import PieChartIcon from '@mui/icons-material/PieChart';
import logo from '../../images/logo-transparent.png';
export const MenuBar = () => (
    <Menu>
        <img src={logo} alt="logo" className="logo" />
        <Typography variant="text" component="h2" color="#cf2338" fontWeight="bold" ml={3} mb={3}>Online Asset Management</Typography>
        <Menu.Item to="/home" primaryText="Home" leftIcon={<BookIcon />} />
        <Menu.Item to="/users" primaryText="Manage User" leftIcon={<PeopleIcon />} />
        <Menu.Item to="/assets" primaryText="Manage Asset" leftIcon={<LabelIcon />} />
        <Menu.Item to="/assignments" primaryText="Manage Assignment" leftIcon={<AssignmentIcon />} />
        <Menu.Item to="/returning" primaryText="Request for Returning" leftIcon={<RedoIcon />} />
        <Menu.Item to="/report" primaryText="Report" leftIcon={<PieChartIcon />} />
    </Menu>
);