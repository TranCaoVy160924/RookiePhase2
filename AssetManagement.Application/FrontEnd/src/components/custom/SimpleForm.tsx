import React, { useState } from 'react'
import { Form, TextInput } from 'react-admin';
import { Box, IconButton } from '@mui/material'
import CheckIcon from '@mui/icons-material/Check';
import ClearIcon from '@mui/icons-material/Clear';

function SimpleForm({ handleSubmit, handleClose }) {
    const [isValid, setIsValid] = useState(true);

    const requiredInput = (values) => {
        const errors: Record<string, any> = {};
        if (!values.name) {
            errors.userName = "This is required";
            setIsValid(true);
        } else if (!values.prefix) {
            errors.password = "This is required";
            setIsValid(true);
        } else {
            setIsValid(false);
            return {};
        }
        return errors;
    }

    return (
        <Form validate={requiredInput} onSubmit={handleSubmit}>
            <Box
                display="flex"
                flexDirection="row"
                width="300px"
                padding="6px 16px"
                boxSizing="border-box"
            >
                <TextInput
                    fullWidth
                    label=""
                    name="name"
                    source="name"
                    sx={{ width:"60%", borderRadius:"unset" }}
                    onChange={(e) => e.preventDefault()}
                    helperText={false}
                />
                <TextInput
                    fullWidth
                    label=""
                    name="prefix"
                    source="prefix"
                    sx={{ width:"15%", borderRadius:"unset" }}
                    onChange={(e) => e.stopPropagation()}
                    helperText={false}
                />
                <Box display="flex" flexDirection="row" >
                    <IconButton type="submit" color="secondary" disabled={isValid}>
                        <CheckIcon fontSize='small' />
                    </IconButton>
                    <IconButton color="secondary" onClick={handleClose}>
                        <ClearIcon fontSize='small' />
                    </IconButton>
                </Box>
            </Box>
        </Form>
    )
}

export default SimpleForm;