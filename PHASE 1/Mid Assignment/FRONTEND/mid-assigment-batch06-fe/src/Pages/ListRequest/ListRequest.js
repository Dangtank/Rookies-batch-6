import { Button, Input, Space, Table, Tag } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import React, { useEffect, useState } from 'react';
import { createData, getAllData } from '../../axiosAPIs';
import { BORROW_BOOKS, BORROW_BOOKS_APPROVE,} from '../../constants';
import styles from './BorrowBooks.module.scss';

const UPDATE_STATUS_REJECT = 'BookRequests/reject';

const ListRequest = () => {
  const [dataState, setDataState] = useState([]);

  const getData = async () => {
    const data = await getAllData(BORROW_BOOKS);
    setDataState(data);
  };

  useEffect(() => {
    getData();
  }, []);

  const handleApproved = async (id) => {
    await createData(BORROW_BOOKS_APPROVE,
      {
        RequestId: id,
        UserName: localStorage.getItem("userName")
      });
    getData();
  };

  const handleRejected = async (id) => {
    await createData(UPDATE_STATUS_REJECT,
      {
        RequestId: id,
        UserName: localStorage.getItem("userName")
      });
    getData();
  };

  const columns = [
    {
      title: 'ID',
      dataIndex: '$id',
      key: '$id',
    },
    {
      title: 'Requested By',
      dataIndex: 'requestedBy',
      key: 'requestedBy',
      sorter: (a, b) => a.requestedBy.localeCompare(b.requestedBy),
    },
    {
      title: 'Request Date',
      dataIndex: 'requestedDate',
      key: 'requestedDate',
      sorter: (a, b) => a.requestedDate.localeCompare(b.requestedDate),
    },
    {
      title: 'Status',
      dataIndex: 'requestStatus',
      key: 'requestStatus',
      sorter: (a, b) => a.requestStatus.localeCompare(b.requestStatus),
      render: (_, { requestStatus }) => (
        <>{<Tag color={requestStatus === '1' ? 'success' : requestStatus === '0' ? 'processing' : 'error'}>{requestStatus}</Tag>}</>
      ),
    },
    {
      title: 'Action',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <Button
            disabled={record.requestStatus === '1' || record.requestStatus === '2'}
            type="primary"
            onClick={() => {
              handleApproved(record.requestId);
            }}
          >
            Approve
          </Button>
          <Button
            disabled={record.requestStatus === '2'}
            type="primary"
            danger
            onClick={() => {
              handleRejected(record.requestId);
            }}
          >
            Reject
          </Button>
        </Space>
      ),
    },
  ];

  return (
    <Content className="container">
      <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
        {' '}
        <div className={styles.headerTable}>
          <h1>List Request</h1>
        </div>
        <Table rowKey={(dataState) => dataState.id} columns={columns} dataSource={dataState} />
      </Space>
    </Content>
  );
};

export default ListRequest;
