import * as React from 'react';
import { AppBar } from 'react-admin';
import Typography from '@mui/material/Typography';

const Index = (props) => (
    <AppBar
        sx={{
            "& .RaAppBar-title": {
                flex: 1,
                textOverflow: "ellipsis",
                whiteSpace: "nowrap",
                overflow: "hidden",
            },
        }}
        {...props}
    >
        <Typography
            variant="h6"
            color="inherit"
            className="Header"
            id="react-admin-title"
        />
        <span />
    </AppBar>
);

export default Index;