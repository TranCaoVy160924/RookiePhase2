import React, { Fragment, ReactEventHandler, ReactElement } from 'react';
import { styled } from '@mui/material/styles';
import PropTypes from 'prop-types';
import { alpha } from '@mui/material/styles';
import ActionDelete from '@mui/icons-material/Delete';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import clsx from 'clsx';
import { UseMutationOptions } from 'react-query';
import {
    MutationMode,
    RaRecord,
    DeleteParams,
    useDeleteWithConfirmController,
    useRecordContext,
    useResourceContext,
    useTranslate,
    RedirectionSideEffect,
} from 'ra-core';
import { Button as MUIButton, ButtonGroup } from '@mui/material';
import { Confirm, DeleteButton } from 'react-admin';
import { Button, ButtonProps } from 'react-admin';
import { Padding } from '@mui/icons-material';

export const CustomDeleteWithConfirmButton = <RecordType extends RaRecord = any>(
    props: DeleteWithConfirmButtonProps<RecordType>
) => {
    const {
        className,
        confirmTitle = 'ra.message.delete_title',
        confirmContent = 'ra.message.delete_content',
        icon = defaultIcon,
        label = 'ra.action.delete',
        mutationMode = 'pessimistic',
        onClick,
        redirect = 'list',
        translateOptions = {},
        mutationOptions,
        ...rest
    } = props;
    const translate = useTranslate();
    const record = useRecordContext(props);
    const resource = useResourceContext(props);

    const {
        open,
        isLoading,
        handleDialogOpen,
        handleDialogClose,
        handleDelete,
    } = useDeleteWithConfirmController({
        record,
        redirect,
        mutationMode,
        onClick,
        mutationOptions,
        resource,
    });

    const titleStype = {
        bgcolor: '#F0EBEB',
        color: "#E80E0E",
        border: "1px solid #000",
        borderRadius: 1
    }

    const contentStyle = {
        border: "1px solid #000",
        borderRadius: 1
    }

    const buttonStyle = {
        bgcolor: "#E80E0E",
        color: "#FFFFFF",
        border: "1px solid #000",
        borderRadius: 1,
        marginRight: 3
    }

    return (
        <Fragment>
            <StyledButton
                onClick={handleDialogOpen}
                label={label}
                className={clsx('ra-delete-button', className)}
                key="button"
                {...rest}
            >
                {icon}
            </StyledButton>
            <Dialog
                open={open}
                onClose={handleDialogClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title" sx={titleStype}>
                    {confirmTitle}
                </DialogTitle>
                <DialogContent sx={contentStyle}>
                    <DialogContentText component={"div"} id="alert-dialog-description">
                        <DialogContentText sx={{
                            padding: 3
                        }}>
                            {confirmContent}
                        </DialogContentText>
                    </DialogContentText>
                    <DialogActions>
                        <ButtonGroup >
                            <MUIButton sx={buttonStyle} onClick={handleDialogClose}>Cancel</MUIButton>
                            <DeleteButton sx={buttonStyle} />
                        </ButtonGroup>
                    </DialogActions>
                </DialogContent>

            </Dialog>
        </Fragment>
    );
};

const defaultIcon = <ActionDelete />;

export interface DeleteWithConfirmButtonProps<
    RecordType extends RaRecord = any,
    MutationOptionsError = unknown
> extends ButtonProps {
    confirmTitle?: string;
    confirmContent?: React.ReactNode;
    icon?: ReactElement;
    mutationMode?: MutationMode;
    onClick?: ReactEventHandler<any>;
    // May be injected by Toolbar - sanitized in Button
    translateOptions?: object;
    mutationOptions?: UseMutationOptions<
        RecordType,
        MutationOptionsError,
        DeleteParams<RecordType>
    >;
    record?: RecordType;
    redirect?: RedirectionSideEffect;
    resource?: string;
}

CustomDeleteWithConfirmButton.propTypes = {
    className: PropTypes.string,
    confirmTitle: PropTypes.string,
    confirmContent: PropTypes.string,
    label: PropTypes.string,
    mutationMode: PropTypes.oneOf(['pessimistic', 'optimistic', 'undoable']),
    record: PropTypes.any,
    redirect: PropTypes.oneOfType([
        PropTypes.string,
        PropTypes.bool,
        PropTypes.func,
    ]),
    resource: PropTypes.string,
    icon: PropTypes.element,
    translateOptions: PropTypes.object,
};

const PREFIX = 'RaDeleteWithConfirmButton';

const StyledButton = styled(Button, {
    name: PREFIX,
    overridesResolver: (props, styles) => styles.root,
})(({ theme }) => ({
    color: theme.palette.error.main,
    '&:hover': {
        backgroundColor: alpha(theme.palette.error.main, 0.12),
        // Reset on mouse devices
        '@media (hover: none)': {
            backgroundColor: 'transparent',
        },
    },
}));