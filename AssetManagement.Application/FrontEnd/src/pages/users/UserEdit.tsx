import { Box, Container, createTheme, ThemeProvider, Typography, unstable_createMuiStrictModeTheme } from "@mui/material";
import React, { useEffect, useState } from "react";
import { DateInput, EditBase, SimpleForm, TextInput, Title } from "react-admin";
import { useParams } from "react-router-dom";
import { assetProvider } from "../../providers/assetProvider/assetProvider";
import { formStyle } from "../../styles/formStyle";
import RadioButtonGroup from "../../components/custom/RadioButtonGroupInput";
import UserEditToolbar from "../../components/toolbar/UserEditToolbar";

const UserEdit = () => {
    let theme = createTheme();
    theme = unstable_createMuiStrictModeTheme();
    const params= useParams();
    const staffCode= params.id;
    const [user, setUser] = useState({
        firstName:'',
        lastName:'',
        staffCode:'',
        dateOfBirth:'',
        joinedDate:'',
        gender:'',
    });

    useEffect(()=>{    
        assetProvider.getOne('user', { id:staffCode }).then(res => {
            setUser(res.data);
        })
    },[])

    return(
        <ThemeProvider theme={theme}>
            <Title title="Manage User > Edit User" />
            <Container component="main">
                <Box sx={formStyle.boxTitleStyle}>
                    <Typography
                        component="h3"
                        variant="h5"
                        sx={formStyle.formTitle}
                    >
                        Edit User
                    </Typography>

                    {user.staffCode?
                        <SimpleForm
                            // validate={requiredInput}
                            toolbar={<UserEditToolbar />}
                            onSubmit={(e)=>{console.log(e)}}
                        >
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    First Name
                                </Typography>
                                <TextInput
                                    label={false}
                                    name="firstName"
                                    source="firstName"
                                    sx={formStyle.textInputStyle }
                                    helperText={false}
                                    InputLabelProps={{ shrink: false }}
                                    defaultValue={user.firstName}
                                    disabled
                                />
                            </Box>
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    Last Name
                                </Typography>
                                <TextInput
                                    label={false}
                                    name="lastName"
                                    source="lastName"
                                    sx={formStyle.textInputStyle }
                                    helperText={false}
                                    InputLabelProps={{ shrink: false }}
                                    defaultValue={user.lastName}
                                    disabled
                                />
                            </Box>
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    Date of Birth *
                                </Typography>
                                <DateInput
                                    label={false}
                                    name="dob"
                                    source="dob"
                                    sx={formStyle.textInputStyle }
                                    helperText={false}
                                    InputLabelProps={{ shrink: false }}
                                    defaultValue={new Date(user.dateOfBirth)}
                                />
                            </Box>
                            <RadioButtonGroup
                                    label=""
                                    row
                                    sx={formStyle.textInputStyle}
                                    source="gender"
                                    choices={[
                                        { id: 0, name: "Male" },
                                        { id: 1, name: "Female" }
                                    ]}
                                    optionText="name"
                                    optionValue="id"
                            />
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    Joined Date *
                                </Typography>
                                <DateInput
                                    label={false}
                                    name="joinedDate"
                                    source="joinedDate"
                                    sx={formStyle.textInputStyle }
                                    helperText={false}
                                    InputLabelProps={{ shrink: false }}
                                    defaultValue={new Date(user.joinedDate)}
                                />
                            </Box>
                        </SimpleForm>
                    :<h2>No user found</h2>}
                </Box>
            </Container>
        </ThemeProvider>
    )
}

export default UserEdit;
