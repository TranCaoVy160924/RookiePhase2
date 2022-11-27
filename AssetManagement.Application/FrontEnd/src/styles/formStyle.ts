import { SxProps, Theme } from "@mui/material";

export const formStyle: Record<string, SxProps<Theme> | undefined> = {
    boxStyle: {
        display: "flex",
        flexDirection: "row",
        width: "650px",
        marginTop: "10px",
    },
    boxTitleStyle: {
        margin: "auto",
        marginTop: 8,
        display: "flex",
        flexDirection: "column",
        width: "700px",
    },
    textInputStyle: {
        width: "430px",
        margin: "0",
        padding: "0",
    },
    typographyStyle: {
        width: "220px",
        margin: "0",
        padding: "0",
        alignSelf: "center",
    },
    editBaseStyle: {
        ".RaEdit-card": { boxShadow: "none" },
        ".RaEdit-main": { width: "750px" },
    },
    createBaseStyle: {
        ".RaCreate-card": { boxShadow: "none" },
        ".RaCreate-main": { width: "750px" },
    },
    formTitle: {
        color:"#cf2338", 
        pb:"40px", 
        fontWeight:"bold"
    },
};
