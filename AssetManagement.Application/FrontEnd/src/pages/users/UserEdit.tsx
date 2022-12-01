import { Box, Container, createTheme, ThemeProvider, Typography, unstable_createMuiStrictModeTheme } from "@mui/material";
import React, { useEffect, useState } from "react";
import { DateInput, EditBase, EditGuesser, number, SelectField, SelectInput, SimpleForm, TextInput, Title } from "react-admin";
import { useParams } from "react-router-dom";
import { assetProvider } from "../../providers/assetProvider/assetProvider";
import { formStyle } from "../../styles/formStyle";
import RadioButtonGroup from "../../components/custom/RadioButtonGroupInput";
import UserEditToolbar from "../../components/toolbar/UserEditToolbar";
import { updateUser } from "../../services/users";

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
        type:''
    });

    useEffect(()=>{    
        assetProvider.getOne('user', { id:staffCode }).then(res => {
            setUser(res.data);
        })
    },[])


    function EditUser(e) {
        console.log(e);
        let changes = {
            dob: e.dob,
            gender: e.gender==='Male'?0:1,
            joinedDate: e.joinedDate,
            Type: e.type
        }
        console.log(changes)
        assetProvider.update('user', {id: user.staffCode, data: changes, previousData: user}).then(
            response => console.log(response)
        ).catch(error => console.log(error))
    }

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
                            onSubmit={(e)=>{EditUser(e)}}
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
                                    fullWidth
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
                                    fullWidth
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
                                    fullWidth
                                />
                            </Box>
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    Gender *
                                </Typography>
                                <RadioButtonGroup
                                    label=""
                                    sx={formStyle.textInputStyle}
                                    source="gender"
                                    choices={[
                                        { id: 0, name: "Male" },
                                        { id: 1, name: "Female" }
                                    ]}
                                    optionText="name"
                                    optionValue="name"
                                    defaultValue={user.gender}
                                />
                            </Box>
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
                                    fullWidth
                                />
                            </Box>
                            <Box sx={formStyle.boxStyle}>
                                <Typography
                                    variant="h6"
                                    sx={formStyle.typographyStyle}
                                >
                                    Type *
                                </Typography>

                                <SelectInput
                                    label="Type"
                                    sx={formStyle.textInputStyle}
                                    source="type"
                                    name="type"
                                    choices={[
                                        { id: 0, name: "Admin" },
                                        { id: 1, name: "Staff" }
                                    ]}
                                    optionText="name"
                                    optionValue="name"
                                    defaultValue={user.type}
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
